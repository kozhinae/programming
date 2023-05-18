#ifndef ALLOCATOR_CALLOCATOR_H
#define ALLOCATOR_CALLOCATOR_H

#include <algorithm>
#include <cmath>
#include <vector>
#include <iostream>

static std::size_t const MEM_ALLOC = 10000;
static std::size_t const k = 10;

template<typename T>
class MemoryPool {
public:
    explicit MemoryPool(): len(MEM_ALLOC / k)
    {
        data = static_cast<T*>(malloc(sizeof(T) * MEM_ALLOC));
    }
    T *allocate(size_t size)
    {
        std::cout << "Allocate" << std::endl;
        T *current = data;
        std::cout << len << std::endl;
        int needed = size / len + (size % len != 0);
        for (int i = 0; i < k; i++)
        {
            if (!used[i])
            {
                bool check = true;
                std::cout << needed << std::endl;
                for (int j = i + 1; j < i + needed - 1; j++)
                {
                    std::cout << j << ' ';
                    if (used[j])
                    {
                        check = false;
                    }
                }
                std::cout << '\n';
                if (check)
                {
                    for(int j = i; j < i + needed; j++)
                    {
                        used[j] = true;
                    }
                    break;
                }
            }
            current += len;
        }
//        std::cout << data << ' ' << current << " ";
        return current;
    }
    void deallocate(T* p, size_t n)
    {
        std::cout << "Deallocate " << p << std::endl;
        int needed = n / len + (n % len != 0), pos = 0;
        T *current = data;
        while (current != p)
        {
            pos++;
            current = current + len;
        }
        for (int i = 0; i < needed; i++)
        {
            used[pos] = false;
            pos++;
        }
    }
    ~MemoryPool() {
        std::cout << "Destructor - POOL " << std::endl;
        delete data;
    }
private:
    T* data;
    bool used[k]{};
    size_t len;
};

template<typename T>
class MemoryManager {
public:
    int counter = 0;
    MemoryPool<T>* pointer = nullptr;
    explicit MemoryManager() {
        std::cout << "Default constructor - memory pool manager" << std::endl;
        pointer = static_cast<MemoryPool<T>*>(new MemoryPool<T>());
        counter = 1;
    }
    void increase_counter() {
        counter += 1;
    }
    ~MemoryManager() {
        counter -= 1;
        std::cout << "Destructor - memory pool manager - " << counter << std::endl;
        if (counter == 0) {
            delete pointer;
        }
    }

    [[nodiscard]] MemoryPool<T> *get_pointer() const {
        return pointer;
    }
};

template<typename T>
class CAllocator {
public:
    typedef size_t size_type;
    typedef ptrdiff_t difference_type;
    typedef T* pointer;
    typedef const T* const_pointer;
    typedef T& reference;
    typedef const T& const_reference;
    typedef T value_type;
    MemoryManager<T>* manager = nullptr;
    explicit CAllocator() {
        std::cout << "Default constructor" << std::endl;
        manager = static_cast<MemoryManager<T> *>(new MemoryManager<T>());
    }
    CAllocator(const CAllocator &allocator){
        if (allocator != *this) {
            std::cout << "Copy constructor" << std::endl;
            manager = allocator.manager;
            manager->increase_counter();
        }
    };
    CAllocator &operator=(const CAllocator<T> &allocator) {
        if (&allocator != this) {
            std::cout << "Operator =" << std::endl;
            manager = allocator.manager;
            manager->increase_count();
        }
        return *this;
    }

    T *allocate(size_t size) {
        T* result = manager->get_pointer()->allocate(size);
        std::cout << "Allocate - count_objects = " << size << " - " << result << std::endl;
        return result;
    }

    void deallocate(T *p, size_t n) {
        std::cout << "Deallocate - count_objects = " << n << " - " << p << std::endl;
        manager->get_pointer()->deallocate(p, n);
    }

    ~CAllocator() {
        delete manager;
    };
    bool operator!=(const CAllocator<T> &rhs) const {
        return manager != rhs.manager;
    }
};

#endif //ALLOCATOR_CALLOCATOR_H
