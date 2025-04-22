import simpy
import random
import pandas as pd
import matplotlib

matplotlib.use('TkAgg')
import matplotlib.pyplot as plt

ARRIVAL_RATE = 10  # λ: интенсивность заявок
SERVICE_RATE = 3  # μ: интенсивность обслуживания
SIM_TIME = 40  # Время моделирования
AGENT_ON_RATE = 1  # Подключение агентов
AGENT_OFF_RATE = 0.5  # Отключение агентов
MAX_AGENTS = 5  # Макс. количество агентов
QUEUE_LIMIT = 30  # Максимальная длина очереди


def run_simulation():
    results = []

    class DynamicServiceSystem:
        def __init__(self, env):
            self.env = env
            self.queue = simpy.Store(env, capacity=QUEUE_LIMIT)
            self.active_agents = 1
            self.total_wait_times = []
            self.queue_lengths = []
            self.agent_count_log = []
            self.lost_requests = 0
            self.total_requests = 0

            self.server_pool = simpy.Resource(env, capacity=self.active_agents)
            self.env.process(self.generator())
            self.env.process(self.agent_dynamics())

        def generator(self):
            while True:
                yield self.env.timeout(random.expovariate(ARRIVAL_RATE))
                self.total_requests += 1
                if len(self.queue.items) >= QUEUE_LIMIT:
                    self.lost_requests += 1
                    continue
                arrival_time = self.env.now
                self.queue.put(arrival_time)
                self.env.process(self.handle_request())

        def handle_request(self):
            with self.server_pool.request() as request:
                result = yield request | self.env.timeout(0.01)
                if request in result:
                    if len(self.queue.items) > 0:
                        arrival_time = yield self.queue.get()
                        wait = self.env.now - arrival_time
                        self.total_wait_times.append(wait)
                        yield self.env.timeout(random.expovariate(SERVICE_RATE))

        def agent_dynamics(self):
            while True:
                on_time = random.expovariate(AGENT_ON_RATE)
                off_time = random.expovariate(AGENT_OFF_RATE)
                yield self.env.timeout(min(on_time, off_time))
                if on_time < off_time and self.active_agents < MAX_AGENTS:
                    self.active_agents += 1
                elif self.active_agents > 1:
                    self.active_agents -= 1
                self.server_pool = simpy.Resource(self.env, capacity=self.active_agents)
                self.agent_count_log.append((self.env.now, self.active_agents))
                self.queue_lengths.append((self.env.now, len(self.queue.items)))

    env = simpy.Environment()
    system = DynamicServiceSystem(env)
    env.run(until=SIM_TIME)

    avg_time = sum(system.total_wait_times) / len(system.total_wait_times) if system.total_wait_times else 0
    avg_queue = sum(length for _, length in system.queue_lengths) / len(system.queue_lengths)
    avg_agents = sum(count for _, count in system.agent_count_log) / len(system.agent_count_log)
    loss_prob = system.lost_requests / system.total_requests if system.total_requests else 0

    results.append({
        "Среднее время пребывания заявки в системе": round(avg_time, 4),
        "Среднее число заявок в очереди": round(avg_queue, 2),
        "Среднее число активных агентов": round(avg_agents, 2),
        "Вероятность потери заявок": round(loss_prob, 4)
    })

    return pd.DataFrame(results), system.agent_count_log, system.queue_lengths


results_df, agent_log, queue_log = run_simulation()
print(results_df)
results_df.to_csv("results5.csv", index=False, encoding="utf-8-sig")

times, agents = zip(*agent_log)
_, queue_lengths = zip(*queue_log)

plt.figure(figsize=(12, 5))
plt.subplot(1, 2, 1)
plt.plot(times, agents, label='Активные агенты')
plt.xlabel("Время")
plt.ylabel("Количество агентов")
plt.title("Динамика агентов")
plt.grid(True)

plt.subplot(1, 2, 2)
plt.plot(times, queue_lengths, label='Длина очереди', color='orange')
plt.xlabel("Время")
plt.ylabel("Заявок в очереди")
plt.title("Динамика очереди")
plt.grid(True)

plt.tight_layout()
plt.show()
