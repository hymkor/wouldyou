Module Module1

    Sub Main()
        Try
            Dim args As String() = System.Environment.GetCommandLineArgs()
            If args.Count < 2 Then
                Console.WriteLine(String.Format("Usage: {0} [-] COMMAND [PARAMETERS]", args(0)))
                Return
            End If
            Dim pinfo1 As New System.Diagnostics.ProcessStartInfo()
            pinfo1.Verb = "RunAs" '*** This is for UAC mode ***
            Dim wait = False
            Dim startArg = 1
            If args(startArg) = "-" Then
                If args.Count < 3 Then
                    Console.WriteLine(String.Format("{0} : too few parameters", args(0)))
                    Return
                End If
                wait = True
                startArg += 1
            End If
            pinfo1.FileName = args(startArg)
            startArg += 1
            If args.Count - 1 > startArg Then
                Dim buffer As New System.Text.StringBuilder()
                buffer.Append(Quote(args(startArg)))
                For i As Integer = startArg + 1 To args.Count - 1
                    buffer.Append(" "c)
                    buffer.Append(Quote(args(i)))
                Next
                pinfo1.Arguments = buffer.ToString()
            Else
                pinfo1.Arguments = ""
            End If
            Debug.Print(pinfo1.Arguments)
            Dim process As System.Diagnostics.Process =
                System.Diagnostics.Process.Start(pinfo1)
            If wait Then
                process.WaitForExit()
                System.Environment.ExitCode = process.ExitCode
            End If
        Catch ex As Exception
#If DEBUG Then
            Console.WriteLine(ex.ToString())
#Else
            Console.Error.WriteLine(ex.Message)
#End If
        Finally
#If DEBUG Then
            Console.ReadLine()
#End If
        End Try
    End Sub

    Function Quote(s As String) As String
        If s.IndexOf(" "c) >= 0 Then
            Return String.Format("""{0}""", s)
        Else
            Return s
        End If
    End Function
End Module
