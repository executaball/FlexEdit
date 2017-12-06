Imports System.IO
Imports System.Reflection
Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Module Module1
    Public Function LoadFont(Asm As Assembly, Name As String, Size As Integer, Style As FontStyle) As Font
        Using Collection As New PrivateFontCollection
            Dim Bytes() As Byte = Module1.FontData(Asm, Name)
            Dim Ptr As IntPtr = Marshal.AllocCoTaskMem(Bytes.Length)
            Marshal.Copy(Bytes, 0, Ptr, Bytes.Length)
            Collection.AddMemoryFont(Ptr, Bytes.Length)
            Marshal.FreeCoTaskMem(Ptr)
            Return New Font(Collection.Families(0), Size, Style)
        End Using
    End Function

    Private Function FontData(Asm As Assembly, Name As String) As Byte()
        Using Stream As Stream = Asm.GetManifestResourceStream(Name)
            If (Stream Is Nothing) Then Throw New Exception(String.Format("Unable to load font '{0}'", Name))
            Dim Buffer() As Byte = New Byte(CInt(Stream.Length - 1)) {}
            Stream.Read(Buffer, 0, CInt(Stream.Length))
            Return Buffer
        End Using
    End Function
End Module
