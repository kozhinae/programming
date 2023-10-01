# Allocator

## Definition
- The allocator releases a large amount of memory during construction.
It is released only at the end of its "life". Memory allocations in the process of "work" do not occur.
- The entire memory is divided into "pieces". The size of the pieces,
as well as their number is parameterized. "Pieces"
of the same size are grouped.
- When requesting a memory allocation of size "N", the allocator searches for a
a free suitable piece of the required size (the nearest
free, suitable by size). If there is no such a piece, then
exception occurs.
- On release, the allocator returns the piece of memory to the list of
free pieces.
