Module Module1
    'Anna Marcy
    '12/12/23
    'Rock Paper Scissors
    Dim input(4) As Integer
    Dim round As Integer
    Dim RAND As New Random
    Dim min = 1, max = 3
    Dim NUM As Integer = RAND.Next(min, max)
    Dim computerturn(4), userturn(4) As String
    Dim outcome(4) As String
    Dim win, lose, tie As Double
    Dim percentage1, percentage2, percentage3 As Double
    'This runs every single sub and function
    Sub Main()
        PrintTittle()
        For i As Integer = 0 To 4
            Console.WriteLine()
            round += 1
            Console.WriteLine("Round " & round)
            GetValidInput()
            ConvertNumToWordUSER()
            ComputerMove()
            ConvertNumToWordCOMPUTER()
            DetermineOutcome()
        Next
        PrintReport()
        Percentages()
    End Sub

    Sub PrintTittle()
        'This prints out the tittle and ASCII art
        Console.WriteLine(".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.")
        Console.WriteLine("|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.")
        Console.WriteLine("' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'")
        Console.WriteLine("    _______           _______               _______")
        Console.WriteLine("---'   ____)      ---'   ____)____     ---'    ____)____")
        Console.WriteLine("      (_____)               ______)               ______)")
        Console.WriteLine("      (_____)               _______)           __________)")
        Console.WriteLine("      (____)               _______)           (____)")
        Console.WriteLine("---.__(___)       ---.__________)      ---.__(___)")
    End Sub
    Function GetValidInput()
        'This gets the users input
        Console.WriteLine("enter 1 for rock, 2 for paper or 3 for scissors: ")
        input(round - 1) = Console.ReadLine
        Return True
    End Function
    Function ComputerMove()
        'this gets the computers turn
        NUM = RAND.Next(min, max)
        Console.WriteLine("Computer move is: " & NUM)
        Return True
    End Function

    Function ConvertNumToWordCOMPUTER()
        'This will convert whatecer the computers turn is into the word
        If NUM = 1 Then
            Console.WriteLine("rock")
            computerturn(round - 1) = "Rock"
        ElseIf NUM = 2 Then
            Console.WriteLine("Paper")
            computerturn(round - 1) = "Paper"
        ElseIf NUM = 3 Then
            Console.WriteLine("scissors")
            computerturn(round - 1) = "Scissors"
        Else
            Console.WriteLine("Invalid Input")
        End If
        Return True
    End Function
    Sub ConvertNumToWordUSER()
        'This converts the users input into the word
        If input(round - 1) = 1 Then
            Console.WriteLine("rock")
            userturn(round - 1) = "Rock"
        ElseIf input(round - 1) = 2 Then
            Console.WriteLine("Paper")
            userturn(round - 1) = "Paper"
        ElseIf input(round - 1) = 3 Then
            Console.WriteLine("scissors")
            userturn(round - 1) = "Scissors"
        Else
            Console.WriteLine("Invalid Input")
        End If
    End Sub
    Sub DetermineOutcome()
        'this determines whether the game was a tie, win, or loss
        Console.WriteLine($"You played {userturn(round - 1)} and the computer played {computerturn(round - 1)}")
        If computerturn(round - 1) = userturn(round - 1) Then
            Console.WriteLine("Its a Tie!")
            outcome(round - 1) = "Tie"
            tie += 1
        ElseIf computerturn(round - 1) = "Rock" AndAlso userturn(round - 1) = "scissors" OrElse computerturn(round - 1) = "Scissors" AndAlso userturn(round - 1) = "Paper" OrElse computerturn(round - 1) = "Paper" AndAlso userturn(round - 1) = "Rock" Then
            Console.WriteLine("You lost! ")
            outcome(round - 1) = "Lost"
            lose += 1
        Else
            Console.WriteLine("You won! ")
            outcome(round - 1) = "Win"
            win += 1
        End If
    End Sub
    Sub printreportline(col1 As String, col2 As String, col3 As String, col4 As String)
        'this is an array and this array helps print out results in less lines
        Console.WriteLine("| {0} | {1} | {2} | {3} |", col1.PadLeft(10), col2.PadLeft(15), col3.PadLeft(15), col4.PadLeft(15))
    End Sub
    Sub PrintReport()
        'This prints out the results as a chart
        Console.WriteLine("####################################################################")
        Console.WriteLine("##################  Rock, Paper, Scissors Report  ##################")
        Console.WriteLine("####################################################################")
        Console.WriteLine("--------------------------------------------------------------------")
        printreportline("Round", "User played", "Computer Played", "Outcome")
        Console.WriteLine("--------------------------------------------------------------------")
        For i As Integer = 0 To 4
            printreportline((i + 1).ToString(), userturn(i), computerturn(i), outcome(i))
            Console.WriteLine("--------------------------------------------------------------------")
        Next
    End Sub
    Sub Percentages()
        'This finds out the percent of the users wins, losses, and ties then prints it out and determines if the user won lost or tie the series
        percentage1 = (win / 5) * 100
        percentage2 = (lose / 5) * 100
        percentage3 = (tie / 5) * 100
        Console.WriteLine($"You won {percentage1}% of the matches")
        Console.WriteLine($"You lost {percentage2}% of the matches")
        Console.WriteLine($"You tied {percentage3}% of the matches")
        If percentage1 > percentage2 AndAlso percentage1 > percentage3 Then
            Console.WriteLine("You won the series")
        ElseIf percentage2 > percentage1 AndAlso percentage2 > percentage3 Then
            Console.WriteLine("You lost the series")
        ElseIf percentage3 > percentage1 AndAlso percentage3 > percentage2 Then
            Console.WriteLine("You tied the series")
        End If
    End Sub
End Module