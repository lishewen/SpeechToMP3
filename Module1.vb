Imports System.IO
Imports System.Speech.Synthesis
Imports NAudio.Lame
Imports NAudio.Wave

Module Module1

    Sub Main(ParamArray args() As String)
        Dim ms As New MemoryStream

        If args.Length <> 2 Then
            Return
        End If

        Dim id = args(0)
        Dim word = args(1)

        Using s As New SpeechSynthesizer
            s.Rate = -2
            s.Volume = 100
            s.SetOutputToWaveStream(ms)
            s.Speak(word)
        End Using

        ms.Position = 0
        Dim mswav As New WaveFileReader(ms)
        Using mp3 As New LameMP3FileWriter("D:\Website\Demo\Files\Speech\" & id & ".mp3", mswav.WaveFormat, 16)
            mswav.CopyTo(mp3)
        End Using
    End Sub

End Module
