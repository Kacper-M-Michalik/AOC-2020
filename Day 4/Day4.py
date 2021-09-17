Pointer = open("Data.txt","r")
Data = Pointer.read().split("\n")
Pointer.close()

RequiredFields = ["byr","iyr","eyr","hgt","hcl","ecl","pid"]
Passports = []

ValidPassports = 0

String = ""
for Line in Data:
    if (Line == ""):
        String+=" "
        Passports.append(String)
        String = ""
    else:
        String += " "+Line

String += " "
Passports.append(String)
        
for Passport in Passports:
    
    print(Passport)
   # print(Passport.find("byr"))
    
    #RF = RequiredFields.copy()
    
   # FoundFields = 0    
   # for Val in RF:
   #     if Val in Passport:
   #         FoundFields += 1

    ValidDetails = 0

    #BYR
    String = ""
    ByrIndex = Passport.find("byr:")
    if (ByrIndex != -1):
        ByrIndex+=4
        while Passport[ByrIndex] != " ":
            String+=Passport[ByrIndex]
            ByrIndex+=1

        String = int(String)

        if (String >= 1920 and String <= 2002):
            ValidDetails+=1
            print("BYR WORKS")

    #IYR
    String = ""
    IyrIndex = Passport.find("iyr:")
    if (IyrIndex != -1):
        IyrIndex+=4
        while Passport[IyrIndex] != " ":
            String+=Passport[IyrIndex]
            IyrIndex +=1
            
        String = int(String)

        if (String >= 2010 and String <= 2020):
            ValidDetails+=1
            print("IYR WORKS")

    #EYR
    String = ""
    EyrIndex = Passport.find("eyr:")
    if (EyrIndex != -1):
        EyrIndex+=4
        while Passport[EyrIndex] != " ":
            String+=Passport[EyrIndex]
            EyrIndex+=1

        String = int(String)

        if (String >= 2020 and String <= 2030):
            ValidDetails+=1
            print("EYR WORKS")

    #HGT
    String = ""
    HgtIndex = Passport.find("hgt:")
    if (HgtIndex != -1):
        HgtIndex+=4
        while Passport[HgtIndex] != " ":
            String+=Passport[HgtIndex]
            HgtIndex+=1

        if ("in" in String):
            if int(String[:len(String)-2]) >= 59 and int(String[:len(String)-2]) <=76:
                ValidDetails+=1
                print("HGT WORKS")
        elif ("cm" in String):
            if int(String[:len(String)-2]) >= 150 and int(String[:len(String)-2]) <= 193:
                ValidDetails+=1
                print("HGT WORKS")
    
    #HCL
    String = ""
    EyrIndex = Passport.find("hcl:")
    if (EyrIndex != -1):
        EyrIndex+=4
        while Passport[EyrIndex] != " ":
            String+=Passport[EyrIndex]
            EyrIndex+=1        

        Valids = True
        if (String[0]=="#"):
            for i in range (1,len(String)):
                if (String[i].isalpha()):
                    if String[i] > "f":
                        Valids = False
        else:
            Valids = False
                
        if Valids == True:
            ValidDetails += 1
            print("HCL WORKS")

    #ECL
    ECLArray = ["amb","blu","brn","gry","grn","hzl","oth"]
    String = ""
    EyrIndex = Passport.find("ecl:")
    if (EyrIndex != -1):
        EyrIndex+=4
        while Passport[EyrIndex] != " ":
            String+=Passport[EyrIndex]
            EyrIndex+=1

        if String in ECLArray:
            ValidDetails+=1
            print("ECL WORKS")
   
    #PID
    String = ""
    EyrIndex = Passport.find("pid:")
    if (EyrIndex != -1):
        EyrIndex+=4
        while Passport[EyrIndex] != " ":
            String+=Passport[EyrIndex]
            EyrIndex+=1

        if (len(String) == 9):
            ValidDetails+=1
            print("PID WORKS")

    print(ValidDetails)
    #if (len(RF) == FoundFields and ValidDetails):
    if (ValidDetails == 7):
        ValidPassports += 1

print()
print("Valid Passports")
print(ValidPassports)
