Imports System.IO
Imports System.Text
Imports Bio
Imports Bio.IO.SAM
Imports System.Text.RegularExpressions

Public Class Form1
#Region "ToolStrips"
    Private Sub ReadCountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadCountsToolStripMenuItem.Click
        Dim Files = SelectFiles("")
        Try

            Dim str As New System.Text.StringBuilder
            For Each File In Files
                Dim Sams As New List(Of Bio.IO.SAM.SAMAlignedSequence)
                For Each Sam In Bam_Parse(File)
                    Sams.Add(Sam)
                Next ' SAM
                str.Append(File.Name).Append(vbTab)
                Dim NofRead = (From x In Sams Select x.QName).Distinct.Count
                str.Append(NofRead).Append(vbTab)
                str.Append(Sams.Count)
                str.AppendLine()
            Next
            Clipboard.SetText(str.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Beep()
    End Sub

    Private Sub AvarageMisMatchIndelsBestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AvarageMisMatchIndelsBestToolStripMenuItem.Click
        Dim Files = SelectFiles("")
        Try
            For Each File In Files
                Dim str As New System.Text.StringBuilder
                str.Append("ReadID").Append(vbTab)
                str.Append("Deletions").Append(vbTab)
                str.Append("Insertions").Append(vbTab)
                str.Append("Matches").Append(vbTab)
                str.Append("MisMatches")

                Dim ALs As New List(Of CMV.MD.M_Ins_Del)
                Dim Sams = Bam_Parse(File)
                For Each Sam In Get_Bests(Sams)
                    Dim MD_String = (From x In Sam.OptionalFields Where x.Tag = "MD").First.Value

                    Dim X1 As New CMV.MD.M_Ins_Del(MD_String, Get_CIGARS(Sam.CIGAR))
                    str.AppendLine()
                    str.Append(Sam.RName).Append(vbTab)
                    str.Append(X1.Deletions_From_Ref_Genome).Append(vbTab)
                    str.Append(X1.Insertions).Append(vbTab)
                    str.Append(X1.Matches).Append(vbTab)
                    str.Append(X1.MisMatches).Append(vbTab)
                    str.Append(X1.NofD_CIGar)
                Next ' SAM
                SaveText(str.ToString, New FileInfo(File.FullName & ".tsv"))
                '     str.Append(ALs.Sum / ALs.Count * 100).AppendLine()

            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Beep()
    End Sub


    Private Sub AvarageAlignedReadsBestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AvarageAlignedReadsBestToolStripMenuItem.Click
        Dim Files = SelectFiles("")
        Try
            Dim str As New System.Text.StringBuilder
            str.Append("Avarage Aligned Lengts Bests").AppendLine()
            For Each File In Files
                str.Append(File.Name).Append(vbTab)
                Dim Sams = Bam_Parse(File)
                Dim Best_ALs As New List(Of Integer)

                For Each Item In Get_Bests(Sams)
                    Best_ALs.Add(Get_Aligned_Length(Item))
                Next
                str.Append(Best_ALs.Sum / Best_ALs.Count).AppendLine()
            Next ' FIle
            Clipboard.SetText(str.ToString)
        Catch ex As Exception
            Dim kj As Int16 = MsgBox(ex.ToString)
        End Try
        Beep()
    End Sub

    Private Sub BlastNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlastNToolStripMenuItem.Click
        Dim IdentityPercents As New Dictionary(Of String, List(Of Double))
        Dim MisMatchPercents As New Dictionary(Of String, List(Of Double))

        Dim files = SelectFiles("Select Blast OutPut in outmft 7 format", "All Tab-Like Files|*.tdt;*.tab;*.txt;*.tsv")
        If IsNothing(files) = True Then Exit Sub
        Try
            Dim str As New System.Text.StringBuilder
            str.Append("FileName").Append(vbTab)
            str.Append("SeqID").Append(vbTab)
            str.Append("MisMatch").Append(vbTab)
            str.Append("Nof Reads").Append(vbTab)
            str.Append("Avarage Identity").AppendLine()
            For Each FIle In files
                For Each Lines In Parse_Group_Lines(FIle, "#") ' Read By Read
                    Dim Used As New List(Of String) ' Take only the first HSP
                    For Each Line In Lines
                        If Line <> "" Then
                            Dim s = Split(Line, vbTab)
                            '    If Used.Contains(s(1)) = False Then
                            If IdentityPercents.ContainsKey(s(1)) = False Then IdentityPercents.Add(s(1), New List(Of Double))
                            If MisMatchPercents.ContainsKey(s(1)) = False Then MisMatchPercents.Add(s(1), New List(Of Double))

                            IdentityPercents(s(1)).Add(s(2)) ' Identity Percents
                            MisMatchPercents(s(1)).Add(s(4)) 'MisMatch
                            Used.Add(s(1))
                        End If
                        '  End If
                    Next
                Next

                For Each o In IdentityPercents
                    str.Append(FIle.Name).Append(vbTab)
                    str.Append(o.Key).Append(vbTab)
                    Dim d = MisMatchPercents(o.Key)
                    str.Append(d.Sum).Append(vbTab)
                    str.Append(o.Value.Count).Append(vbTab)
                    str.Append(o.Value.Sum / o.Value.Count).AppendLine()

                Next

            Next
            Clipboard.SetText(str.ToString)
            Beep()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub GeneralCoverageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralCoverageToolStripMenuItem.Click
        Dim Files = SelectFiles("")
        Try
            Dim str As New System.Text.StringBuilder
            str.Append("Covearage Bests").AppendLine()
            For Each File In Files
                Dim Length As Long = Get_Length(File)
                str.Append(File.Name).Append(vbTab)
                Dim Sams = Bam_Parse(File)
                Dim Best_ALs As New List(Of Integer)
                For Each Item In Get_Bests(Sams)
                    Best_ALs.Add(Get_Aligned_Length(Item))
                Next
                str.Append(Best_ALs.Sum / Length).AppendLine()
            Next ' FIle
            Clipboard.SetText(str.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Beep()
    End Sub

    Private Sub ReadCountsFromFastqToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadCountsFromFastqToolStripMenuItem.Click
        Dim Files = SelectFiles("Fasta and Fastq (*.fa,*.fas,*.fasta,*.fast1,*.fq)|*.fa;*.fas;*.fasta;*.fq;*.fastq", "Select Fastq FIles")
        Dim str As New System.Text.StringBuilder
        str.Append("Read Counts From FastQ files").AppendLine()
        Try
            For Each file In Files
                str.Append(file.Name).Append(vbTab)
                Dim Seqs = Read_Seqs(file)
                str.Append(Seqs.Count).AppendLine()
            Next
            Clipboard.SetText(str.ToString)
            Beep()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

#End Region

#Region "IO & Text"
    Private Shared Function SelectFiles(Filter As String, Optional Title As String = "Select Bam Files") As List(Of FileInfo)

        Dim ofd1 As New OpenFileDialog
        ofd1.Title = Title
        If Filter = "" Then ofd1.Filter = "Bam (*.bam)|*.bam"

        ofd1.Multiselect = True

        If ofd1.ShowDialog = DialogResult.OK Then
            Dim Out As New List(Of FileInfo)
            Dim Names = ofd1.FileNames

            For Each FileName In ofd1.FileNames
                Out.Add(New FileInfo(FileName))
            Next

            Return Out
        End If
        Return Nothing
    End Function

    Private Function Read_Seqs(File As FileInfo) As List(Of Bio.ISequence)
        Dim x As New FileStream(File.FullName, FileMode.Open)
        Dim Seqs As New List(Of Bio.ISequence)
        Dim fa = Bio.IO.SequenceParsers.FindParserByFileName(File.FullName)
        For Each Seq In fa.Parse(x)
            Seqs.Add(Seq)
        Next
        x.Close()
        Return Seqs
    End Function

    Private Shared Iterator Function Parse_Group_Lines(File As FileInfo, Not_Start_With As String) As IEnumerable(Of List(Of String))
        If File.Exists = True Then
            Dim cLines As New List(Of String)
            Using sr As New StreamReader(File.FullName)
                Do
                    Dim Line = sr.ReadLine
                    If Line.StartsWith(Not_Start_With) = True Then
                        If cLines.Count > 0 Then
                            Yield (cLines)
                            cLines.Clear()

                        End If

                    Else
                        cLines.Add(Line)
                    End If
                Loop Until sr.EndOfStream = True
                Yield cLines


            End Using
        End If
    End Function

    Private Shared Function GetText(x As List(Of String), Optional Separator As String = vbCrLf) As String
        Dim str As New StringBuilder
        If IsNothing(x) = True Then Return String.Empty
        For Each s In x
            str.Append(s).Append(Separator)
        Next
        If str.Length >= Separator.Length Then str.Length -= Separator.Length
        Return str.ToString
    End Function

    Private Shared Sub SaveText(ByVal Text As String, File As FileInfo)
        Try
            Using sg As New System.IO.StreamWriter(File.FullName)
                sg.Write(Text)
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Shared Function GetNewFile(fileInSearch As FileInfo, v As String) As FileInfo
        Dim t = fileInSearch.DirectoryName & "\" & fileInSearch.Name.TrimEnd(fileInSearch.Extension.ToCharArray) & v
        Dim Out As String = fileInSearch.FullName.Replace(fileInSearch.Extension, v)
        Dim x As New FileInfo(t)
        Return x

    End Function

    Private Shared Iterator Function Bam_Parse(File As FileInfo) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
        Using s As New FileStream(File.FullName, FileMode.Open)
            Dim bamReader As New Bio.IO.BAM.BAMParser()
            For Each SAM In bamReader.Parse(s)
                Yield SAM
            Next

        End Using
    End Function

    Private Shared Function Import_Seq() As Bio.ISequence
        Dim ofd1 As New OpenFileDialog
        ofd1.Title = "Select Seq in fasta format"

        ofd1.Multiselect = False
        Try
            If ofd1.ShowDialog = DialogResult.OK Then
                Dim x As New FileStream(ofd1.FileName, FileMode.Open)

                Dim fa = Bio.IO.SequenceParsers.FindParserByFileName(ofd1.FileName)
                Return fa.ParseOne(x)

            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

#End Region

#Region "Routines"
    Private Shared Function Get_CIGARS(CIGAR As String) As List(Of KeyValuePair(Of String, Integer))
        Dim CIGARS As New List(Of KeyValuePair(Of String, Integer))
        Dim cI As String = ""
        For i1 = 0 To CIGAR.Count - 1
            Dim s As String = CIGAR(i1)
            Dim i As Integer = 0
            If Integer.TryParse(s, 1) Then
                cI = cI & s
            Else
                If cI = String.Empty Then cI = "0"
                Dim t As New KeyValuePair(Of String, Integer)(s, cI)
                CIGARS.Add(t)
                cI = ""
            End If
        Next
        Return CIGARS
    End Function

    Private Shared Function Get_Length(File As FileInfo) As Long
        Using sr As New FileStream(File.FullName, FileMode.Open)
            Dim sa As New Bio.IO.BAM.BAMParser()
            Dim t = sa.GetHeader(sr)
            Dim l As Long
            For Each item In t.ReferenceSequences
                l += item.Length
            Next
            Return l
        End Using

    End Function

    Private Function Get_Aligned_Length(SAM As Bio.IO.SAM.SAMAlignedSequence) As Integer
        Dim l = SAM.QuerySequence.Count
        For Each Item In Get_CIGARS(SAM.CIGAR)

            If Item.Key = "S" Then ' Or Item.Key = "D" Then
                l -= Item.Value
            End If
        Next
        Return l
    End Function

    Private Iterator Function Get_Bests(sams As IEnumerable(Of SAMAlignedSequence)) As IEnumerable(Of SAMAlignedSequence)
        Dim gr = From x In sams Group By x.QName Into Group

        For Each g In gr
            Dim Bests As New Dictionary(Of Integer, Bio.IO.SAM.SAMAlignedSequence)
            For Each Item In g.Group
                Dim l = Get_Aligned_Length(Item)
                If Bests.ContainsKey(l) = False Then Bests.Add(l, Item)
            Next
            Dim r = From x In Bests Order By x.Key Descending

            Yield r.First.Value
        Next

    End Function

#End Region

End Class

Public Class MD
    Public Property Nof_Mapping As Integer
    Public Property Sams As List(Of Bio.IO.SAM.SAMAlignedSequence)
    Public Property Values As New List(Of M_Ins_Del)
    Public Property nof_diff_Matches As Integer
    Public Property nof_diff_Insertions As Integer
    Public Property nof_diff_Deletions As Integer

    Public Class M_Ins_Del
        Public Property MisMatches As Integer
        Public Property Matches As Integer
        Public Property Insertions As Integer
        Public Property Deletions_From_Ref_Genome As Integer
        Public Property NofD_CIGar As Integer
        Public Sub New(MdString As String, Cigars As List(Of KeyValuePair(Of String, Integer)))
            Dim Matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(MdString, "[0-9]+")
            Dim All = System.Text.RegularExpressions.Regex.Matches(MdString, "[\^ACGNT]+")


            For Each match As Match In Matches
                Dim groups As GroupCollection = match.Groups

                For Each gr As Group In groups
                    If gr.Success = True Then
                        Me.Matches += gr.Value
                    End If
                Next
            Next

            For Each match As Match In All
                Dim groups As GroupCollection = match.Groups
                For Each gr As Group In groups
                    If gr.Value.StartsWith("^") Then
                        Deletions_From_Ref_Genome += gr.Value.Length - 1
                    Else
                        MisMatches += gr.Value.Length
                    End If
                Next
            Next
            Me.Insertions = (From x In Cigars Where x.Key = "I" Select x.Value).Sum
            Me.NofD_CIGar = (From x In Cigars Where x.Key = "D" Select x.Value).Sum
        End Sub
    End Class


End Class
