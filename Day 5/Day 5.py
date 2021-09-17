import math

Pointer = open("Data.txt","r")
Data = Pointer.read().split("\n")

Pointer.close()

Seats = []

for i in range(0,128):
    for j in range(0,8):
        Seats.append([i,j])


HighestScore = 0

for Seat in Data:

    RowLower = 0
    RowUpper = 127
    
    ColumnLower = 0
    ColumnUpper = 7
    
    for Char in Seat:
        if Char == "F":
            RowUpper = math.floor((RowLower+RowUpper)/2)
        elif (Char == "B"):            
            RowLower = math.ceil((RowLower+RowUpper)/2)
        elif Char == "L":
            ColumnUpper = math.floor((ColumnLower+ColumnUpper)/2)
        elif (Char == "R"):            
            ColumnLower = math.ceil((ColumnLower+ColumnUpper)/2)

    Seats.remove([RowUpper,ColumnUpper])

    Score = RowUpper*8+ColumnUpper

    if (Score > HighestScore):
        HighestScore = Score

for Seat in Seats:
    print(Seat)


print(HighestScore)
