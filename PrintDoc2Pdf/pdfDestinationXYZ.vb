
Imports System

Namespace sharpPDF
	''' <summary>
	''' Class that represents a pdfDestination of XYZ type.
	''' </summary>
	Friend Class pdfDestinationXYZ
		Implements IPdfDestination

		Private _left As Integer
		Private _top As Integer
		Private _zoom As Integer

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="left">Left margin</param>
		''' <param name="top">Top margin</param>
		''' <param name="zoom">Zoom</param>
		Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal zoom As Integer)
			_left = left
			_top = top
			_zoom = zoom
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the destination
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getDestinationValue() As String Implements IPdfDestination.getDestinationValue
            Return "/XYZ " + _left.ToString() + " " + _top.ToString() + " " + ((Convert.ToSingle(_zoom)) / 100).ToString().Replace(",", ".")
        End Function

		''' <summary>
		''' Method that format the zoom value
		''' </summary>
		''' <returns>String with zoom value</returns>
		Private Function getFormattedZoom() As String
			Dim returnValue As String
			If _zoom >= 100 Then
				returnValue = _zoom.ToString()
				returnValue = returnValue.Substring(0, returnValue.Length - 2) + "." + returnValue.Substring(returnValue.Length - 2, 2)
			Else
				returnValue = "." + _zoom.ToString()
			End If
			Return returnValue
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
