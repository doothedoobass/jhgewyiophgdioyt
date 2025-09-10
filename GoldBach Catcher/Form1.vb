Imports System.ComponentModel
Imports System.Text

Public Class Form1
    Private WithEvents bgWorker As New BackgroundWorker()
    Private WithEvents clearTimer As New Timer()
    Private primes As New List(Of Long)()
    Private currentEvenNumber As Long = 4
    Private matrixText As New List(Of String)()
    Private binaryText As New List(Of String)()
    Private rnd As New Random()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the prime numbers list with the first prime
        primes.Add(2)

        ' Configure the background worker
        bgWorker.WorkerReportsProgress = True
        bgWorker.WorkerSupportsCancellation = True

        ' Initialize progress bars
        ProgressBar1.Value = 0
        ProgressBar2.Value = 0
        ProgressBar3.Value = 0
        ProgressBar4.Value = 0

        ' Set up the clear timer (7 seconds)
        clearTimer.Interval = 7000
        clearTimer.Enabled = True
        AddHandler clearTimer.Tick, AddressOf ClearTimer_Tick

        ' Start the background worker
        If Not bgWorker.IsBusy Then
            bgWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub ClearTimer_Tick(sender As Object, e As EventArgs)
        ' Clear textboxes every 7 seconds
        If TextBox1.Lines.Length > 20 Then TextBox1.Clear()
        If TextBox2.Lines.Length > 20 Then TextBox2.Clear()
        If TextBox3.Lines.Length > 10 Then TextBox3.Clear()
    End Sub

    Private Sub BgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        While Not worker.CancellationPending
            ' Update progress bars with random values for visual effect
            worker.ReportProgress(0, New Object() {"progress", rnd.Next(0, 101), rnd.Next(0, 101),
                                                  rnd.Next(0, 101), rnd.Next(0, 101)})

            ' Find the next prime number if needed
            If primes.Count < 2 OrElse primes.Last() * 2 < currentEvenNumber Then
                FindNextPrime()
            End If

            ' Try to find a Goldbach pair for the current even number
            Dim result = FindGoldbachPair(currentEvenNumber)

            If result IsNot Nothing Then
                ' Generate binary and matrix representations
                Dim binaryPrime1 = ToBinaryString(result.Prime1)
                Dim binaryPrime2 = ToBinaryString(result.Prime2)
                Dim binarySum = ToBinaryString(currentEvenNumber)

                ' Generate matrix-style falling digits
                Dim matrixLine = GenerateMatrixLine()

                ' Report the found pair
                worker.ReportProgress(0, New Object() {"result", result.Prime1, result.Prime2,
                                                      currentEvenNumber, binaryPrime1, binaryPrime2,
                                                      binarySum, matrixLine})
            End If

            ' Move to the next even number
            currentEvenNumber += 2

            ' Skip some numbers to prevent system overload
            If currentEvenNumber Mod 50 = 0 Then
                System.Threading.Thread.Sleep(100)
            End If
        End While
    End Sub

    Private Sub BgWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        Dim data As Object() = TryCast(e.UserState, Object())

        If data IsNot Nothing Then
            Dim updateType As String = CStr(data(0))

            If updateType = "progress" Then
                ' Update progress bars
                ProgressBar1.Value = CInt(data(1))
                ProgressBar2.Value = CInt(data(2))
                ProgressBar3.Value = CInt(data(3))
                ProgressBar4.Value = CInt(data(4))
            ElseIf updateType = "result" Then
                ' Update the text boxes with binary encoded values
                Dim prime1 As Long = CLng(data(1))
                Dim prime2 As Long = CLng(data(2))
                Dim sum As Long = CLng(data(3))
                Dim binaryPrime1 As String = CStr(data(4))
                Dim binaryPrime2 As String = CStr(data(5))
                Dim binarySum As String = CStr(data(6))
                Dim matrixLine As String = CStr(data(7))

                ' Add binary values to textboxes with matrix styling
                TextBox1.AppendText(binaryPrime1 & Environment.NewLine)
                TextBox2.AppendText(binaryPrime2 & Environment.NewLine)

                ' Add the equation to textbox3
                TextBox3.AppendText($"{prime1} + {prime2} = {sum}" & Environment.NewLine)

                ' Update the label with the current solution
                Label1.Text = $"Solution: = {prime1} + {prime2} = {sum}"

                ' Add matrix line to textboxes for visual effect
                TextBox1.AppendText(matrixLine & Environment.NewLine)
                TextBox2.AppendText(matrixLine & Environment.NewLine)
            End If
        End If
    End Sub

    Private Function FindGoldbachPair(evenNumber As Long) As GoldbachPair
        ' Find two primes that sum to the even number
        For i As Integer = 0 To primes.Count - 1
            Dim prime1 As Long = primes(i)
            Dim prime2 As Long = evenNumber - prime1

            If prime2 < prime1 Then
                Exit For ' No need to continue if prime2 is smaller than prime1
            End If

            If IsPrime(prime2) Then
                ' Add prime2 to our primes list if it's not already there
                If Not primes.Contains(prime2) Then
                    primes.Add(prime2)
                End If
                Return New GoldbachPair With {.Prime1 = prime1, .Prime2 = prime2}
            End If
        Next

        Return Nothing
    End Function

    Private Sub FindNextPrime()
        Dim candidate As Long = primes.Last() + 1

        While True
            If IsPrime(candidate) Then
                primes.Add(candidate)
                Exit While
            End If
            candidate += 1

            ' Add a small delay for very large numbers to prevent freezing
            If candidate Mod 1000 = 0 Then
                System.Threading.Thread.Sleep(1)
            End If
        End While
    End Sub

    Private Function IsPrime(n As Long) As Boolean
        If n < 2 Then Return False
        If n = 2 Then Return True
        If n Mod 2 = 0 Then Return False

        Dim limit As Long = Math.Sqrt(n)
        For i As Long = 3 To limit Step 2
            If n Mod i = 0 Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Function ToBinaryString(number As Long) As String
        ' Convert number to binary string with spaces for readability
        Dim binaryStr = Convert.ToString(number, 2)
        Dim result As New StringBuilder()

        For i As Integer = 0 To binaryStr.Length - 1
            result.Append(binaryStr(i))
            If (i + 1) Mod 4 = 0 And i < binaryStr.Length - 1 Then
                result.Append(" ")
            End If
        Next

        Return result.ToString()
    End Function

    Private Function GenerateMatrixLine() As String
        ' Generate a line of falling matrix-style digits (0s and 1s)
        Dim lineLength = rnd.Next(5, 15)
        Dim sb As New StringBuilder()

        For i As Integer = 1 To lineLength
            sb.Append(If(rnd.NextDouble() > 0.5, "1", "0"))
        Next

        Return sb.ToString()
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Clean up when the form is closing
        If bgWorker.IsBusy Then
            bgWorker.CancelAsync()
        End If
        clearTimer.Enabled = False
    End Sub
End Class

' Helper class to store prime pairs
Public Class GoldbachPair
    Public Property Prime1 As Long
    Public Property Prime2 As Long
End Class