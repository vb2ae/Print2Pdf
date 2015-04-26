
Imports System

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a generic PDF element.
	''' </summary>
	Friend MustInherit Class pdfElement
		Implements IWritable

		''' <summary>
		''' Element's color
		''' </summary>
		Protected _strokeColor As New pdfColor(predefinedColor.csNoColor)
		''' <summary>
		''' Border's color
		''' </summary>
		Protected _fillColor As New pdfColor(predefinedColor.csNoColor)
		''' <summary>
		''' X position of the element
		''' </summary>
		Protected _coordX As Integer
		''' <summary>
		''' Y position of the element
		''' </summary>
		Protected _coordY As Integer
		''' <summary>
		''' Element's ID
		''' </summary>
		Protected _objectID As Integer

		''' <summary>
		''' Border's color
		''' </summary>
		Public Property strokeColor() As pdfColor
			Get
				Return _strokeColor
			End Get

			Set
				_strokeColor = value
			End Set
		End Property

		''' <summary>
		''' Element's Color
		''' </summary>
		Public Property fillColor() As pdfColor
			Get
				Return _fillColor
			End Get

			Set
				_fillColor = value
			End Set
		End Property

		''' <summary>
		''' X position in the PDF document
		''' </summary>
		Public Property coordX() As Integer
			Get
				Return _coordX
			End Get
			Set
				_coordX = value
			End Set
		End Property

		''' <summary>
		''' Y position in the PDF document
		''' </summary>
		Public Property coordY() As Integer
			Get
				Return _coordY
			End Get
			Set
				_coordY = value
			End Set
		End Property

		''' <summary>
		''' Element's ID
		''' </summary>
		Public Property objectID() As Integer
			Get
				Return _objectID
			End Get
			Set
				_objectID = value
			End Set
		End Property

		''' <summary>
		''' Method that returns the PDF codes to write the generic element in the document. It must be implemented by the derived class
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public MustOverride Function getText() As String Implements IWritable.getText

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
