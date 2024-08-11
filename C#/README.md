**Reworked material**

Encapsulation, concealment, composition, polymorphism, introspection, SOLID

**Assignment**

• Implement the object model of a fantasy space travel simulator

• Cover the solution with modular tests

**Wording**

The Space Research Department needs a system for calculating the duration of space routes in different environments and calculating the possibilities and optimality of passing data on routes by certain ships.

**Environment**

• Ordinary space for movement in this environment ships must have impulse engines.

•	The high-density space nebula for moving in this environment pulse engines have a sufficiently low efficiency, so their use is not advisable. In addition, such nebulae have a large spatial area, so movement through them is possible only by special subspace channels. These channels are of a certain length, so to pass through them the ship must be able to pass through the channel completely, it cannot do so in two turns. Special jump engines are required to move through subspace channels.

•	The nebulosity of the nitric particles for movement in this environment of ships must have a pulse engine. Contact with the nitrous particles reduces the efficiency of pulse engines, so to optimally pass through such nebulae, it is necessary to use pulse engines of exponential acceleration.
Each environment may contain a corresponding obstacle.

**Engines**

• The pulse engine of class C is a standard pulse engine that produces a constant speed of an average value and has a fairly low fuel consumption (active plasma).

•	The class E impulse engine, the exponential acceleration impulse engine, produces a speed that increases exponentially with the ship's acceleration by this motor. This behavior requires a higher fuel consumption than for a class C engine.

•	Jump engine. There are several classes of jump engines (Alpha, Omega, Gamma), that differ in the range of subspace channels and formula for calculating the consumption of special fuel - gravitational matter. Alpha is linear, Omega is logarithmic (~n log n), and Gamma is quadratic.

Pulse engines always use a certain amount of fuel to start.
The fuel price is set at the Fuel Exchange and counted in credits of the Mining Guild.

**Obstacles**

• Meteorites and small asteroids are encountered in ordinary space, inflicting low damage to the deflectors of the ship, the damage to the hull is calculated from its strength and the mass-dimensional ratio of the ship’s characteristics to the obstacle.

•	Anti-matter bursts occur in subspace channels. To reflect this obstacle, the ship must be equipped with special photonic deflectors, the damage to the body is not inflicted, but, their non-reflected photon deflector impact will lead to the death of the crew.

•	Cosmowhales are found in nebulae of nitric particles because they feed on them. The Cosmos is a species of whale. They inflict critical damage to the deflectors of the ship and also destroy it, in case of lack of deflectors, due to their monstrous dimensions. To avoid contact with the spaceships can be used anti-nitric emitter, it mask the signal of nitric particles, which leads to the fact that the tracking area of the ship becomes unattractive territory for them. May encounter different population densities (different number of collisions per obstacle).

**Ships**

• Shuttle Simple ship equipped with a pulse engine class C. Has no deflectors, has a body class 1 strength, and low mass-dimensional characteristics.

•	Vaklaus Research ship. Equipped with a class E pulse engine and a Gamma jump engine, has deflectors class 1, a class 2 strength body, and average mass-dimensional characteristics.

•	Mercean The Retrieval Ship. Equipped with an E-class pulse motor and an anti-nitric radiator, has deflectors of class 2, a body of strength class 2, and average mass-dimensional characteristics.

•	Stella Diplomatic ship. Equipped with a pulse engine class C and an Omega jump engine class, has deflectors class 1, a body class 1 strength, and low mass-dimensional characteristics.

•	Avgur Battleship. Equipped with a class E impulse motor and an Alpha jump motor, has deflectors class 3, a class 3 strength body, and large mass-dimensional characteristics.

**Deflectors**

• Class 1 resists damage from two small asteroids or one meteor, after being repelled - deactivated

• Class 2 resists damage from ten small asteroids or three meteors, and after these obstacles are repelled, they are disabled

• Class 3 resists damage from 40 small asteroids, 10 meteors or one space whale, and is disabled when repelled

• Photon deflectors modification of the deflector, allowing to reflect 3 anti-matter flashes. can be installed on any class of deflectors.

**Body strength classes**

• Class 1 resists damage from one small asteroid, any further damage will destroy the ship

• Class 2 resists damage from five small asteroids or two meteors, any further damage will destroy the ship

• Class 3 resists damage from 20 small asteroids or five meteors, any further damage will destroy the ship

**Route**

• Consists of several sections of the path

• The path represents distance and any environment

• The result of the passage may be 
o Success Contains the route time, fuel spent on this route

o Loss of ship occurs in case of lack of jump engine range

o Destruction of the ship

o Crew Death

**Test cases**

•	Route of medium length in high-density space nebula. Process two ships ([Theory]): Shuttle and Augur. The first one has no jump engines, the second has insufficient range. Both must not complete the route.

•	An anti-matter flare in a subspace channel. Process two ships ([Theory]): Vaclas and Vaclas with photon deflectors. In the first case, the route should not be crossed due to loss of crew, in the second - crossed.

•	Cosmo-Whale in a nitrin particle nebula. Process three ships ([Theory]): Vaklops, Avgur and Mercean. The first one was destroyed after the collision, the second one only lost its shields, and the third one was not touched.

•	Short route in ordinary space. Launch Shuttle and Vaklas. Tqq. Vaklas has a high cost of flight, then the Shuttle should be optimal for this route.

•	Medium-length route in dense space nebula. Let’s launch Augur and Stella. Tqq. Avgura’s possible range of passage through subspace channels is less - Stella should be chosen.

• Route in the nitrin haze. Launch Shuttle and Vaclas. Vacas should be selected.
