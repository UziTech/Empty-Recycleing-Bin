Public Class frmMain
    Private Declare Function SHEmptyRecycleBin Lib "shell32.dll" Alias "SHEmptyRecycleBinA" (ByVal hWnd As Integer, ByVal pszRootPath As String, ByVal dwFlags As Integer) As Integer
    Const SHERB_NOPROGRESSUI As Short = &H1S
    Private Shared m_vb6FormDefInstance As frmMain
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmMain
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmMain
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmMain)
            m_vb6FormDefInstance = Value
        End Set
    End Property
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim retvaL As Object
        retvaL = SHEmptyRecycleBin(frmMain.DefInstance.Handle.ToInt32, "", SHERB_NOPROGRESSUI)
        Close()
    End Sub
End Class
