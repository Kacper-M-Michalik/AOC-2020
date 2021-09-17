Pointer = open("Data.txt","r")
Data = Pointer.read().splitlines()
Pointer.close()

TestVals = [[1,1],[3,1],[5,1],[7,1],[1,2]]
Result = []

for Val in TestVals:
    
    SlopeX = Val[0]
    SlopeY = Val[1]
    TreesEncountered = 0
    x,y = 0,0
    
    while y < len(Data)-1:

        y+=SlopeY
        x+=SlopeX
        
        if x >= len(Data[y]):
            x-=len(Data[y])

        if Data[y][x] == "#":
            TreesEncountered+=1
            #Data[y] = Data[y][:x]+"X"+Data[y][x+1:]
        
            #Data[y] = Data[y][:x]+"O"+Data[y][x+1:]
    
    Result.append(TreesEncountered)
    print(TreesEncountered)

print(Result)
