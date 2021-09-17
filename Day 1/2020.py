Pointer = open("Data.txt","r")
array = Pointer.readlines()
for i in range(0,len(array)):
    array[i] = int(array[i])
Pointer.close()


for i in range(0,len(array)):
    for j in range(i+1,len(array)):        
        for k in range(j+1,len(array)):
            if array[i]+array[j]+array[k] == 2020:
                print(array[i])
                print(array[j])
                print(array[k])
                print(array[i]*array[k]*array[j])
