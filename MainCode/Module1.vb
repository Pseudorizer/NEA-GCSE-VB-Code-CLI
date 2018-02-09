Imports System.IO

Module Module1
    Public Sub Main()
        Dim check As String
        Dim repeat As Boolean = False
        Dim root As String = Path.GetPathRoot(Environment.CurrentDirectory)
        Dim lp As Boolean = False

        Do
            If Not Directory.Exists(root + "NeaPermFolder") Then
                Console.WriteLine("")
                Console.WriteLine("Is this your first time running the software? Yes or No?")
                Dim c As String = Console.ReadLine()

                If c.ToLower = "yes" Then
                    FirstRun()
                ElseIf c.ToLower = "no" Then
                    PermFoldERR(root)
                Else
                    Console.WriteLine("Incorrect Response")
                    lp = True
                End If
            ElseIf Directory.Exists(root + "NeaPermFolder") Then

            End If
        Loop While lp = True

        Dim read As String = My.Computer.FileSystem.ReadAllText(root + "NeaPermFolder\path.txt")
        read = read.Trim()

        Do
            Console.WriteLine(" ")
            Console.WriteLine("Do you have an account? Yes or No.")
            check = Console.ReadLine

            If check.ToLower = "yes" Then
                acchecknew(read)
            ElseIf check.ToLower = "no" Then
                accreate(read)
            Else
                Console.WriteLine("Incorrect response")
                repeat = True
            End If
        Loop While repeat = True
    End Sub

    Sub PermFoldERR(ByVal root)
        Dim permlocation As String = "NeaPermFolder"
        Dim realdir As String
        Dim lm As Boolean = False
        Dim lf As Boolean = False
        Dim read As StreamReader
        Dim write As StreamWriter

        Console.WriteLine(" ")
        Console.WriteLine("Error, NeaPermFolder not found. If you have moved the application to a different drive please enter 1")
        Console.WriteLine("If your folder containing user information and questions still exists but NeaPermFolder is gone please enter 2")
        Dim ch As String = Console.ReadLine()

        If ch = 1 Then
            Do
                Console.WriteLine("")
                Console.WriteLine("Please enter the drive you had the application on originally. I.E. E:\")
                realdir = Console.ReadLine()
                If Not Directory.Exists(realdir + permlocation) Then
                    Console.WriteLine("Directory not found. Please make sure you entered the right drive or that it actually exists")
                    Console.WriteLine("If the folder doesn't exist, please enter retry to try again")
                    Console.WriteLine("Else press enter")
                    Dim realdirq As String = Console.ReadLine()
                    If realdirq.ToLower = "retry" Then
                        PermFoldERR(root)
                    Else
                        lm = True
                    End If
                ElseIf Directory.Exists(realdir + permlocation) Then
                    Directory.CreateDirectory(root + permlocation)

                    Dim fc As FileStream = File.Create(root + permlocation + "\path.txt")
                    fc.Close()

                    write = My.Computer.FileSystem.OpenTextFileWriter(root + permlocation + "\path.txt", True)
                    read = My.Computer.FileSystem.OpenTextFileReader(realdir + permlocation + "\path.txt")
                    Dim dir As String = read.ReadLine
                    write.WriteLine(dir)
                    write.Close()
                    read.Close()

                    Console.WriteLine("")
                    Console.WriteLine("Done, retrying...")
                    Console.WriteLine("Success")
                    lm = False
                End If
            Loop While lm = True
        ElseIf ch = 2 Then
            Console.WriteLine("")
            Console.WriteLine("You will now go through the first time setup again")
            Console.WriteLine("Please enter the exact folder name. No data will be overwritten")
            FirstRun()
        End If

        Main()
    End Sub

    Sub FirstRun()
        Dim folder As String
        Dim drive As String = Path.GetPathRoot(Environment.CurrentDirectory)
        Dim write As System.IO.StreamWriter

        Console.WriteLine("")
        Console.WriteLine("This is the setup for where your information, user accounts and questions for this software will be stored")
        Console.WriteLine("Please enter your folder name")
        folder = Console.ReadLine

        Console.WriteLine("")
        Console.WriteLine("Creating Directories...")
        Console.WriteLine("-------------------------")

        Dim l As String = (drive + folder + "\Questions")
        Dim ls As String = (drive + folder + "\")

        Directory.CreateDirectory(l + "\Computer Science")
        Directory.CreateDirectory(l + "\Computer Science\Easy")
        Directory.CreateDirectory(l + "\Computer Science\Medium")
        Directory.CreateDirectory(l + "\Computer Science\Hard")

        Directory.CreateDirectory(l + "\History")
        Directory.CreateDirectory(l + "\History\Easy")
        Directory.CreateDirectory(l + "\History\Medium")
        Directory.CreateDirectory(l + "\History\Hard")

        Directory.CreateDirectory(l + "\Music")
        Directory.CreateDirectory(l + "\Music\Easy")
        Directory.CreateDirectory(l + "\Music\Medium")
        Directory.CreateDirectory(l + "\Music\Hard")

        Console.WriteLine("Done")
        Console.WriteLine("Delete " + drive + "NeaPermFolder to change file location")
        Console.WriteLine("Remember you still need to create the questions if they do not exist!")

        Dim dir As String = drive + "NeaPermFolder"
        Directory.CreateDirectory(dir)

        Dim writefile As FileStream = File.Create(dir + "\path.txt")
        writefile.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(dir + "\path.txt", True)
        write.WriteLine(ls)
        write.Close()
        Dim read As String = My.Computer.FileSystem.ReadAllText(dir + "\path.txt")
        read = read.Trim()

        accreate(read)

        Console.WriteLine("Proceeding to account creation...")
    End Sub

    Sub accreate(ByVal read)
        Dim name As String
        Dim password As String
        Dim age As String
        Dim year As String

        Console.WriteLine("")
        Console.WriteLine("Account Creation")
        Console.WriteLine("----------------------------")

        Console.WriteLine(" ")
        Console.WriteLine("Please enter your name")
        name = Console.ReadLine

        Console.WriteLine("Please enter your password")
        password = Console.ReadLine

        Console.WriteLine("Please enter your age")
        age = Console.ReadLine

        Console.WriteLine("Please enter your year group")
        year = Console.ReadLine

        Dim shortuser As String = Left(name, 3) + age

        Console.WriteLine("Your username is " & shortuser)

        filewrite(password, name, age, year, shortuser, read)
    End Sub

    Sub filewrite(ByVal password, ByVal name, ByVal age, ByVal year, ByVal shortuser, ByVal read)

        Dim write As System.IO.StreamWriter
        Dim path As String = read & shortuser

        If Directory.Exists(path) = True Then
            Console.WriteLine(" ")
            Console.WriteLine("Your profile already exists")
            Console.WriteLine("----------------------------")
            acchecknew(read)
        End If

        Directory.CreateDirectory(path)
        Dim writeuser As FileStream = File.Create(path & "\Username.txt")
        writeuser.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(path + "\Username.txt", True)
        write.WriteLine(shortuser)
        write.Close()

        Dim writepass As FileStream = File.Create(path & "\Password.txt")
        writepass.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(path + "\Password.txt", True)
        write.WriteLine(password)
        write.Close()

        Dim writeage As FileStream = File.Create(path & "\Age.txt")
        writeage.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(path + "\Age.txt", True)
        write.WriteLine(age)
        write.Close()

        Dim writename As FileStream = File.Create(path & "\Name.txt")
        writename.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(path + "\Name.txt", True)
        write.WriteLine(name)
        write.Close()

        Dim writegroup As FileStream = File.Create(path & "\Group.txt")
        writegroup.Close()
        write = My.Computer.FileSystem.OpenTextFileWriter(path + "\Group.txt", True)
        write.WriteLine(year)
        write.Close()

        acchecknew(read)
    End Sub

    Sub acchecknew(ByVal read)
        Dim shortuser As String
        Console.WriteLine(" ")
        Console.WriteLine("Please enter your username.")
        shortuser = Console.ReadLine

        Dim cpass As String
        Dim passerr As Boolean = False
        Dim passretry As String
        Dim locationuser As String = read & shortuser & "\Username.txt"
        Dim locationpass As String = read & shortuser & "\Password.txt"
        Dim usrcomp As Integer
        Dim passcomp As Integer

        If My.Computer.FileSystem.FileExists(locationuser) = True Then 'Checks username
            Dim curfile As String = My.Computer.FileSystem.ReadAllText(locationuser)
            If usrcomp = StrComp(shortuser, curfile, CompareMethod.Text) = 0 Then
                Console.WriteLine(" ")
                Console.WriteLine("Username matches")
            End If
        ElseIf My.Computer.FileSystem.FileExists(locationuser) = False Then
            Console.WriteLine("Incorrect Username")
            acchecknew(read)
        End If


        Do 'Checks password

            Console.WriteLine(" ")
            Console.WriteLine("Please enter your password")
            cpass = Console.ReadLine

            If My.Computer.FileSystem.FileExists(locationpass) = True Then
                Dim curfile2 As String = My.Computer.FileSystem.ReadAllText(locationpass)
                curfile2 = curfile2.Trim()
                If passcomp = StrComp(cpass, curfile2, CompareMethod.Text) = -1 Then 'Why does -1 work?
                    Console.WriteLine("Password matches. Login successful")
                    Subchoice(shortuser, read)
                ElseIf passcomp = StrComp(cpass, curfile2, CompareMethod.Text) = 0 Then
                    Console.WriteLine("Password Incorrect. If you want to try a different username type RETRY. Else press ENTER.")
                    passretry = Console.ReadLine
                    If passretry.ToLower = "retry" Then
                        acchecknew(read)
                    Else
                        passerr = True
                    End If
                Else
                    Console.WriteLine("Something went wrong")
                End If
            End If
        Loop While passerr = True
    End Sub

    Sub Subchoice(ByVal shortuser, ByVal read)
        Dim choicesub As String
        Dim choicesubdiff As String
        Dim suberr As Boolean = False

        Do
            Console.WriteLine(" ")
            Console.WriteLine("Choose your subject, Computer Science, History or Music?")
            choicesub = Console.ReadLine()

            If choicesub = "computer science" Or choicesub.ToLower = "history" Or choicesub.ToLower = "music" Then
                Do
                    Console.WriteLine("What difficulty, easy, medium or hard?")
                    choicesubdiff = Console.ReadLine()
                    If choicesubdiff.ToLower = "easy" Or choicesubdiff.ToLower = "medium" Or choicesubdiff.ToLower = "hard" Then
                        QuestionSub(shortuser, choicesubdiff, choicesub, read)
                    Else
                        Console.WriteLine("Difficulty not found")
                        suberr = True
                    End If
                Loop While suberr = True
            Else
                Console.WriteLine("Subject not found")
                suberr = True
            End If
        Loop While suberr = True
    End Sub

    Public Function QAGet(ByVal l, ByVal dir)
        Dim sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(dir) 'Opens local var dir from QuestionSub
        Dim v As String

        For i = 1 To l 'Reads from line 1 to int var l from QuestionSub which makes sr.readline read the next line down which contains the text
            sr.ReadLine()
        Next

        v = sr.ReadLine 'Assigns v the contents of var sr

        Return v
    End Function

    Sub QuestionSub(ByVal shortuser, ByVal choicesubdiff, ByVal choicesub, ByVal read)
        Dim total As Integer = 0
        Dim line As Integer = 2
        Dim questiondir As String = read + "\Questions\" + choicesub + "\" + choicesubdiff + "\questions.txt"
        Dim answerdir As String = read + "\Questions\" + choicesub + "\" + choicesubdiff + "\answers.txt"
        Dim q As String
        Dim a As String
        Dim ua As String
        Dim comp As Integer
        Dim time As Date = Now
        Dim qnum As Integer = 0
        Dim qper As Double
        Dim over As String

        Do
            q = QAGet(line, questiondir) 'Uses the function to get the question
            a = QAGet(line, answerdir) 'Uses the function to get the answer

            If a = "" And q = "" Then 'Checks if any questions are left
                Exit Do
            End If

            Console.WriteLine(" ")
            Console.WriteLine(q) 'Writes to console
            ua = Console.ReadLine()

            If comp = StrComp(ua, a, CompareMethod.Text) = -1 Then '-1 is working again??? Why?
                Console.WriteLine("Correct")
                total = total + 1 'Adds one to total
                line = line + 2 'lets the program automatically read the next correct lines
                qnum = qnum + 1 'lets me work out the percentage later on
            ElseIf comp = StrComp(ua, a, CompareMethod.Text) = 0 Then
                Console.WriteLine("The answer was " + a)
                line = line + 2
                qnum = qnum + 1
            Else
                Console.WriteLine("What have you done?")
                QuestionSub(shortuser, choicesubdiff, choicesub, read)
            End If
        Loop 'Loops until the if statement exits the do loop

        qper = total / qnum * 100 'Works out the percentage

        Console.WriteLine(" ")
        Console.WriteLine("You got a score of " & total)
        Console.WriteLine("With a percentage of " & qper & "%")
        Console.WriteLine("Report exported. Check user folder")

        Dim usr As String = Left(shortuser, 3) 'Creates shorter username
        Dim path As String = read + shortuser
        Dim fpath As String = path + "\Scores\" + choicesub + "\" + choicesubdiff + "\Scores.txt"

        If Not Directory.Exists(path + "\Scores\" + choicesub + "\" + choicesubdiff) Then 'Creates a directory for scores in the users profile based on the subject and difficulty
            Directory.CreateDirectory(path + "\Scores\" + choicesub + "\" + choicesubdiff)
            Dim fileCreate As FileStream = File.Create(fpath)
            fileCreate.Close()
        ElseIf Not File.Exists(fpath) Then 'Checks if the file scores.txt exists, if not create it
            Dim fileCreate As FileStream = File.Create(fpath)
            fileCreate.Close()
        Else

        End If

        Select Case total
            Case 0
                File.AppendAllText(fpath, vbCrLf & "User: " + usr + "|" & " Grade: 1C | With a score Of " & total & "| Percentage: " & qper & "%" & "| Difficulty: " & choicesubdiff & " | Quiz type: " & choicesub & " | At " & time)
                Console.WriteLine("You got a grade 1c")
            Case 1
                File.AppendAllText(fpath, vbCrLf & "User: " + usr + "|" & " Grade: 2C | With a score Of " & total & "| Percentage: " & qper & "%" & "| Difficulty: " & choicesubdiff & " | Quiz type: " & choicesub & " | At " & time)
                Console.WriteLine("You got a grade 2c")
            Case 2
                File.AppendAllText(fpath, vbCrLf & "User: " + usr + "|" & " Grade: 3C | With a score Of " & total & "| Percentage: " & qper & "%" & "| Difficulty: " & choicesubdiff & " | Quiz type: " & choicesub & " | At " & time)
                Console.WriteLine("You got a grade 3c")
            Case 3
                File.AppendAllText(fpath, vbCrLf & "User: " + usr + "|" & " Grade: 4C | With a score Of " & total & "| Percentage: " & qper & "%" & "| Difficulty: " & choicesubdiff & " | Quiz type: " & choicesub & " | At " & time)
                Console.WriteLine("You got a grade 4c")
            Case Else
                Console.WriteLine("Something went wrong, i don't how you did it.")
        End Select

        Dim overerr As Boolean = False

        Do
            Console.WriteLine(" ")
            Console.WriteLine("Would you like to A replay this quiz, B choose another subject, C quit or D logout")
            over = Console.ReadLine

            If over.ToLower = "a" Then
                QuestionSub(shortuser, choicesubdiff, choicesub, read)
            ElseIf over.ToLower = "b" Then
                Subchoice(shortuser, read)
            ElseIf over.ToLower = "c" Then
                End
            ElseIf over.ToLower = "d" Then
                Main()
            Else
                Console.WriteLine("Use A, B, C or D")
                overerr = True
            End If
        Loop While overerr = True
    End Sub
End Module
