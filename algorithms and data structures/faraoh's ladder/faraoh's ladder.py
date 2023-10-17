m, n=map(int, input().split())
A=[list(map(int, input().split())) for i in range (m)]
B=[[0]]
#fill in the matrix of values, by rows
for i in range(1, m+1):
    B.append([0]*(i))
    v=0
    for j in range(1, i):
        v+=A[i-j-1][0]*A[i-1][1]
        B[i][-1-j]=B[i-1][-j]+v
C=[[0]*(m+1) for i in range (n)]
#traversal from 1 to n-1 of the desired step, looking for min
for k in range(1, n):
    #traversal of all steps inside the sought minimum to the step
    for l in range(k+1, m+1):
        if k==1:
            C[k][l]=B[l][0]
        else:
            z=100000000000000000
            #options to find the minimum
            for p in range(k-1, l):
                z=min(C[k-1][p]+B[l][p], z)
            C[k][l]=z
z=100000000000000000
#we know where the last step ends, so we only need to calculate the function for the m step
if n>1:
    for p in range(n-1, m):
        z=min(C[n-1][p]+B[m][p], z)
else:
    z=B[m][0]
C.append(z)
    
print(C[-1])
