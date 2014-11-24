<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnIncreaseBet = New System.Windows.Forms.Button()
        Me.btnDecreaseBet = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbSeasonsSelect = New System.Windows.Forms.PictureBox()
        Me.pbHeartsSelect = New System.Windows.Forms.PictureBox()
        Me.pbClassicSelect = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pbStripPokerSelect = New System.Windows.Forms.PictureBox()
        Me.pbLOTRSelect = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbSeasonsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHeartsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClassicSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStripPokerSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLOTRSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(643, 617)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 23)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Apostar"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(674, 635)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 39)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnIncreaseBet
        '
        Me.btnIncreaseBet.BackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseBet.BackgroundImage = CType(resources.GetObject("btnIncreaseBet.BackgroundImage"), System.Drawing.Image)
        Me.btnIncreaseBet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIncreaseBet.FlatAppearance.BorderSize = 0
        Me.btnIncreaseBet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseBet.ForeColor = System.Drawing.Color.Black
        Me.btnIncreaseBet.Location = New System.Drawing.Point(769, 635)
        Me.btnIncreaseBet.Name = "btnIncreaseBet"
        Me.btnIncreaseBet.Size = New System.Drawing.Size(53, 39)
        Me.btnIncreaseBet.TabIndex = 31
        Me.btnIncreaseBet.UseVisualStyleBackColor = False
        '
        'btnDecreaseBet
        '
        Me.btnDecreaseBet.BackColor = System.Drawing.Color.Transparent
        Me.btnDecreaseBet.BackgroundImage = CType(resources.GetObject("btnDecreaseBet.BackgroundImage"), System.Drawing.Image)
        Me.btnDecreaseBet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDecreaseBet.FlatAppearance.BorderSize = 0
        Me.btnDecreaseBet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecreaseBet.Location = New System.Drawing.Point(615, 635)
        Me.btnDecreaseBet.Name = "btnDecreaseBet"
        Me.btnDecreaseBet.Size = New System.Drawing.Size(53, 39)
        Me.btnDecreaseBet.TabIndex = 30
        Me.btnDecreaseBet.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(7, 574)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(364, 100)
        Me.Panel1.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 73)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dinero €"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(828, 574)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 100)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(453, 467)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 101)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbSeasonsSelect
        '
        Me.pbSeasonsSelect.BackgroundImage = Global.Poker1.My.Resources.Resources.SeasonsDeck
        Me.pbSeasonsSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSeasonsSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSeasonsSelect.InitialImage = Nothing
        Me.pbSeasonsSelect.Location = New System.Drawing.Point(89, 13)
        Me.pbSeasonsSelect.Name = "pbSeasonsSelect"
        Me.pbSeasonsSelect.Size = New System.Drawing.Size(57, 75)
        Me.pbSeasonsSelect.TabIndex = 36
        Me.pbSeasonsSelect.TabStop = False
        '
        'pbHeartsSelect
        '
        Me.pbHeartsSelect.BackgroundImage = Global.Poker1.My.Resources.Resources.DeckHearts
        Me.pbHeartsSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbHeartsSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbHeartsSelect.Location = New System.Drawing.Point(48, 13)
        Me.pbHeartsSelect.Name = "pbHeartsSelect"
        Me.pbHeartsSelect.Size = New System.Drawing.Size(57, 75)
        Me.pbHeartsSelect.TabIndex = 35
        Me.pbHeartsSelect.TabStop = False
        '
        'pbClassicSelect
        '
        Me.pbClassicSelect.BackgroundImage = Global.Poker1.My.Resources.Resources.DeckClassic
        Me.pbClassicSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbClassicSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClassicSelect.Location = New System.Drawing.Point(7, 13)
        Me.pbClassicSelect.Name = "pbClassicSelect"
        Me.pbClassicSelect.Size = New System.Drawing.Size(57, 75)
        Me.pbClassicSelect.TabIndex = 34
        Me.pbClassicSelect.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(447, 635)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pbStripPokerSelect
        '
        Me.pbStripPokerSelect.BackgroundImage = Global.Poker1.My.Resources.Resources.StripPokerDeck
        Me.pbStripPokerSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStripPokerSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStripPokerSelect.InitialImage = Nothing
        Me.pbStripPokerSelect.Location = New System.Drawing.Point(122, 12)
        Me.pbStripPokerSelect.Name = "pbStripPokerSelect"
        Me.pbStripPokerSelect.Size = New System.Drawing.Size(57, 75)
        Me.pbStripPokerSelect.TabIndex = 40
        Me.pbStripPokerSelect.TabStop = False
        '
        'pbLOTRSelect
        '
        Me.pbLOTRSelect.BackgroundImage = Global.Poker1.My.Resources.Resources.LOTRDeck
        Me.pbLOTRSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLOTRSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbLOTRSelect.InitialImage = Nothing
        Me.pbLOTRSelect.Location = New System.Drawing.Point(152, 12)
        Me.pbLOTRSelect.Name = "pbLOTRSelect"
        Me.pbLOTRSelect.Size = New System.Drawing.Size(57, 75)
        Me.pbLOTRSelect.TabIndex = 41
        Me.pbLOTRSelect.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1052, 686)
        Me.Controls.Add(Me.pbLOTRSelect)
        Me.Controls.Add(Me.pbStripPokerSelect)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbSeasonsSelect)
        Me.Controls.Add(Me.pbHeartsSelect)
        Me.Controls.Add(Me.pbClassicSelect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnIncreaseBet)
        Me.Controls.Add(Me.btnDecreaseBet)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Ultimate Poker"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbSeasonsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHeartsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClassicSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStripPokerSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLOTRSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnIncreaseBet As System.Windows.Forms.Button
    Friend WithEvents btnDecreaseBet As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbSeasonsSelect As System.Windows.Forms.PictureBox
    Friend WithEvents pbHeartsSelect As System.Windows.Forms.PictureBox
    Friend WithEvents pbClassicSelect As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pbStripPokerSelect As System.Windows.Forms.PictureBox
    Friend WithEvents pbLOTRSelect As System.Windows.Forms.PictureBox

End Class
