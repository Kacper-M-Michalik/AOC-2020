Pointer = open("Day2Data.txt","r")
ReadArray = Pointer.readlines()
Pointer.close()

ValidPasswords = 0

def ContainsStrTimes(TestString,ToFindString):
    Num = 0
    for Char in TestString:
        if Char == ToFindString:
            Num +=1

    return Num

for i in range(0,len(ReadArray)):

    Min = 0
    Max = 0

    IndexForMax = 0
    for j in range(0,len(ReadArray[i])):
        if ReadArray[i][j] == "-":
            Min = int(ReadArray[i][:j])
            IndexForMax = j+1

    SpaceNotFound = True
    j = IndexForMax
    while SpaceNotFound:
        if ReadArray[i][j] == " ":            
            Max = int(ReadArray[i][IndexForMax:j])            
            SpaceNotFound = False
        j+=1

    Char = ReadArray[i][j]
    TestString = ReadArray[i][j+3:]
    
    #Val = ContainsStrTimes(TestString,Char)
    # (Val >= Min and Val <= Max):
    #    ValidPasswords+=1

    if ( (TestString[Min-1] == Char and TestString[Max-1] != Char) or (TestString[Min-1] != Char and TestString[Max-1] == Char) ):
        ValidPasswords+=1
    

print("Result")
print(ValidPasswords)
