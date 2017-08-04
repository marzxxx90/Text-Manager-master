Public Class ExpiryCollection
    Inherits System.Collections.CollectionBase

    Public ReadOnly Property Item(ByVal index As Integer) As Expiry
        Get
            ' The appropriate item is retrieved from the List object and 
            ' explicitly cast to the Widget type, then returned to the 
            ' caller.
            Return CType(List.Item(index), Expiry)
        End Get
    End Property

    Public Sub Add(ByVal contact As Expiry)
        ' Invokes Add method of the List object to add a widget.
        List.Add(contact)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        ' Check to see if there is a widget at the supplied index.
        If index > Count - 1 Or index < 0 Then
            ' If no widget exists, a messagebox is shown and the operation is 
            ' cancelled.
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            ' Invokes the RemoveAt method of the List object.
            List.RemoveAt(index)
        End If
    End Sub

    Public Sub ClearAllAuctionedItem()
        Dim x As Integer = 0
        For Each expItm As Expiry In Me
            If expItm.AuctionDate <= Now.Date Then
                Console.WriteLine(String.Format("PT#{0} removed", expItm.TicketNumber))
                Me.Remove(x)
            End If
            x += 1
        Next
    End Sub
End Class
