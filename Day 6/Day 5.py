Pointer = open("Data.txt","r")
Data = Pointer.read().split("\n")
Pointer.close()

CurrentGroup = []
CurrentLetters = []
CurrentLettersRepeatCount = []

Sum = 0

for Form in Data:
    
    if (Form == ""):

        for Person in CurrentGroup:
            for Char in Person:
                if Char not in CurrentLetters:
                    CurrentLetters.append(Char)
                    CurrentLettersRepeatCount.append(1)
                else:
                    i = CurrentLetters.index(Char)
                    CurrentLettersRepeatCount[i] = CurrentLettersRepeatCount[i]+1

        ToAdd = 0
        for Num in CurrentLettersRepeatCount:
            if Num == len(CurrentGroup):
                ToAdd+=1
                
        Sum += ToAdd
        CurrentLettersRepeatCount.clear()
        CurrentGroup.clear()
        CurrentLetters.clear()

    else:
        CurrentGroup.append(Form)

print(Sum)

