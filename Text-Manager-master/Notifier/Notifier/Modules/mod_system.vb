Module mod_system
    Public devMode As Boolean = False

    Public Function GetAppPath() As String
        Dim i As Integer
        Dim strAppPath As String
        strAppPath = System.Reflection.Assembly.GetExecutingAssembly.Location()
        i = strAppPath.Length - 1
        Do Until strAppPath.Substring(i, 1) = "\"
            i = i - 1
        Loop
        strAppPath = strAppPath.Substring(0, i)
        Return strAppPath
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException( _
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            Return outArr
        End If
    End Function
End Module
