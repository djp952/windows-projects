namespace wmpclean
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.m_folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.m_optionsGroup = new System.Windows.Forms.GroupBox();
			this.m_rollupGracenoteGenres = new System.Windows.Forms.CheckBox();
			this.m_undoReplayGainChanges = new System.Windows.Forms.CheckBox();
			this.m_generateMissingWMTrackNumberTags = new System.Windows.Forms.CheckBox();
			this.m_replaceArtistWithAlbumArtist = new System.Windows.Forms.CheckBox();
			this.m_removeVolumeLevelingTags = new System.Windows.Forms.CheckBox();
			this.m_generateMissingAlbumTags = new System.Windows.Forms.CheckBox();
			this.m_removeCollectionTags = new System.Windows.Forms.CheckBox();
			this.m_replaceAlbumArt = new System.Windows.Forms.CheckBox();
			this.m_removeAlbumArt = new System.Windows.Forms.CheckBox();
			this.m_browseForMediaFolder = new System.Windows.Forms.Button();
			this.m_staticLibraryLocation = new System.Windows.Forms.Label();
			this.m_mediaFolder = new System.Windows.Forms.TextBox();
			this.m_clean = new System.Windows.Forms.Button();
			this.m_currentFolder = new System.Windows.Forms.Label();
			this.m_validationGroup = new System.Windows.Forms.GroupBox();
			this.m_verifyGenresCDDBCompliant = new System.Windows.Forms.CheckBox();
			this.m_verifyNoVariousArtistAuthors = new System.Windows.Forms.CheckBox();
			this.m_checkFileNamesConformant = new System.Windows.Forms.CheckBox();
			this.m_verifyArtworkExists = new System.Windows.Forms.CheckBox();
			this.m_validateTrackNumbers = new System.Windows.Forms.CheckBox();
			this.m_validateTagsAgainstFolder = new System.Windows.Forms.CheckBox();
			this.m_selectTypical = new System.Windows.Forms.LinkLabel();
			this.m_clearAllSafe = new System.Windows.Forms.LinkLabel();
			this.m_replayGainGroup = new System.Windows.Forms.GroupBox();
			this.m_gainVeryHighRadio = new System.Windows.Forms.RadioButton();
			this.m_rgainPreventClip = new System.Windows.Forms.CheckBox();
			this.m_rgainModeGroup = new System.Windows.Forms.GroupBox();
			this.m_rgainTracks = new System.Windows.Forms.RadioButton();
			this.m_rgainAlbum = new System.Windows.Forms.RadioButton();
			this.m_gainHighRadio = new System.Windows.Forms.RadioButton();
			this.m_gainMediumRadio = new System.Windows.Forms.RadioButton();
			this.m_gainLowRadio = new System.Windows.Forms.RadioButton();
			this.m_applyReplayGain = new System.Windows.Forms.CheckBox();
			this.m_selectAllValidations = new System.Windows.Forms.LinkLabel();
			this.m_scanGroup = new System.Windows.Forms.GroupBox();
			this.m_scanAudioStream = new System.Windows.Forms.CheckBox();
			this.m_optionsGroup.SuspendLayout();
			this.m_validationGroup.SuspendLayout();
			this.m_replayGainGroup.SuspendLayout();
			this.m_rgainModeGroup.SuspendLayout();
			this.m_scanGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_folderBrowser
			// 
			this.m_folderBrowser.Description = "Please select the root folder of your Windows Media Player library";
			this.m_folderBrowser.ShowNewFolderButton = false;
			// 
			// m_optionsGroup
			// 
			this.m_optionsGroup.Controls.Add(this.m_rollupGracenoteGenres);
			this.m_optionsGroup.Controls.Add(this.m_undoReplayGainChanges);
			this.m_optionsGroup.Controls.Add(this.m_generateMissingWMTrackNumberTags);
			this.m_optionsGroup.Controls.Add(this.m_replaceArtistWithAlbumArtist);
			this.m_optionsGroup.Controls.Add(this.m_removeVolumeLevelingTags);
			this.m_optionsGroup.Controls.Add(this.m_generateMissingAlbumTags);
			this.m_optionsGroup.Controls.Add(this.m_removeCollectionTags);
			this.m_optionsGroup.Controls.Add(this.m_replaceAlbumArt);
			this.m_optionsGroup.Controls.Add(this.m_removeAlbumArt);
			this.m_optionsGroup.Location = new System.Drawing.Point(368, 60);
			this.m_optionsGroup.Name = "m_optionsGroup";
			this.m_optionsGroup.Size = new System.Drawing.Size(444, 204);
			this.m_optionsGroup.TabIndex = 0;
			this.m_optionsGroup.TabStop = false;
			this.m_optionsGroup.Text = "Cleaning";
			// 
			// m_rollupGracenoteGenres
			// 
			this.m_rollupGracenoteGenres.AutoSize = true;
			this.m_rollupGracenoteGenres.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_rollupGracenoteGenres.Location = new System.Drawing.Point(16, 160);
			this.m_rollupGracenoteGenres.Name = "m_rollupGracenoteGenres";
			this.m_rollupGracenoteGenres.Size = new System.Drawing.Size(350, 18);
			this.m_rollupGracenoteGenres.TabIndex = 12;
			this.m_rollupGracenoteGenres.Text = "Roll up track Genres based on contents of genre-mappings.dat file";
			this.m_rollupGracenoteGenres.UseVisualStyleBackColor = true;
			this.m_rollupGracenoteGenres.CheckedChanged += new System.EventHandler(this.OnRollupGenresChanged);
			// 
			// m_undoReplayGainChanges
			// 
			this.m_undoReplayGainChanges.AutoSize = true;
			this.m_undoReplayGainChanges.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_undoReplayGainChanges.Location = new System.Drawing.Point(16, 180);
			this.m_undoReplayGainChanges.Name = "m_undoReplayGainChanges";
			this.m_undoReplayGainChanges.Size = new System.Drawing.Size(391, 18);
			this.m_undoReplayGainChanges.TabIndex = 11;
			this.m_undoReplayGainChanges.Text = "Undo Replay Gain volume changes made to MP3 files (leaves analysis tags)";
			this.m_undoReplayGainChanges.UseVisualStyleBackColor = true;
			this.m_undoReplayGainChanges.CheckedChanged += new System.EventHandler(this.OnRemoveReplayGain);
			// 
			// m_generateMissingWMTrackNumberTags
			// 
			this.m_generateMissingWMTrackNumberTags.AutoSize = true;
			this.m_generateMissingWMTrackNumberTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_generateMissingWMTrackNumberTags.Location = new System.Drawing.Point(16, 120);
			this.m_generateMissingWMTrackNumberTags.Name = "m_generateMissingWMTrackNumberTags";
			this.m_generateMissingWMTrackNumberTags.Size = new System.Drawing.Size(349, 18);
			this.m_generateMissingWMTrackNumberTags.TabIndex = 10;
			this.m_generateMissingWMTrackNumberTags.Text = "Clean and rebuild track number tags, using file name as necessary";
			this.m_generateMissingWMTrackNumberTags.UseVisualStyleBackColor = true;
			this.m_generateMissingWMTrackNumberTags.CheckedChanged += new System.EventHandler(this.OnGenerateWmTrackNumbersChanged);
			// 
			// m_replaceArtistWithAlbumArtist
			// 
			this.m_replaceArtistWithAlbumArtist.AutoSize = true;
			this.m_replaceArtistWithAlbumArtist.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_replaceArtistWithAlbumArtist.Location = new System.Drawing.Point(16, 140);
			this.m_replaceArtistWithAlbumArtist.Name = "m_replaceArtistWithAlbumArtist";
			this.m_replaceArtistWithAlbumArtist.Size = new System.Drawing.Size(437, 18);
			this.m_replaceArtistWithAlbumArtist.TabIndex = 8;
			this.m_replaceArtistWithAlbumArtist.Text = "Replace Artist tags with Album Artist tags (Ignores \'Various Artists\' and \'Soundt" +
				"rack\')";
			this.m_replaceArtistWithAlbumArtist.UseVisualStyleBackColor = true;
			this.m_replaceArtistWithAlbumArtist.CheckedChanged += new System.EventHandler(this.OnReplaceArtistTagsChanged);
			// 
			// m_removeVolumeLevelingTags
			// 
			this.m_removeVolumeLevelingTags.AutoSize = true;
			this.m_removeVolumeLevelingTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_removeVolumeLevelingTags.Location = new System.Drawing.Point(16, 100);
			this.m_removeVolumeLevelingTags.Name = "m_removeVolumeLevelingTags";
			this.m_removeVolumeLevelingTags.Size = new System.Drawing.Size(251, 18);
			this.m_removeVolumeLevelingTags.TabIndex = 7;
			this.m_removeVolumeLevelingTags.Text = "Remove Windows Media Volume Leveling tags";
			this.m_removeVolumeLevelingTags.UseVisualStyleBackColor = true;
			this.m_removeVolumeLevelingTags.CheckedChanged += new System.EventHandler(this.OnRemoveVolumeLevelingChanged);
			// 
			// m_generateMissingAlbumTags
			// 
			this.m_generateMissingAlbumTags.AutoSize = true;
			this.m_generateMissingAlbumTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_generateMissingAlbumTags.Location = new System.Drawing.Point(16, 80);
			this.m_generateMissingAlbumTags.Name = "m_generateMissingAlbumTags";
			this.m_generateMissingAlbumTags.Size = new System.Drawing.Size(371, 18);
			this.m_generateMissingAlbumTags.TabIndex = 6;
			this.m_generateMissingAlbumTags.Text = "Generate missing Album Name and Album Artist tags from folder layout";
			this.m_generateMissingAlbumTags.UseVisualStyleBackColor = true;
			this.m_generateMissingAlbumTags.CheckedChanged += new System.EventHandler(this.OnGenerateAlbumTagsChanged);
			// 
			// m_removeCollectionTags
			// 
			this.m_removeCollectionTags.AutoSize = true;
			this.m_removeCollectionTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_removeCollectionTags.Location = new System.Drawing.Point(16, 60);
			this.m_removeCollectionTags.Name = "m_removeCollectionTags";
			this.m_removeCollectionTags.Size = new System.Drawing.Size(311, 18);
			this.m_removeCollectionTags.TabIndex = 5;
			this.m_removeCollectionTags.Text = "Remove Data Provider and Windows Media Collection tags";
			this.m_removeCollectionTags.UseVisualStyleBackColor = true;
			this.m_removeCollectionTags.CheckedChanged += new System.EventHandler(this.OnRemoveCollectionTagsChanged);
			// 
			// m_replaceAlbumArt
			// 
			this.m_replaceAlbumArt.AutoSize = true;
			this.m_replaceAlbumArt.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_replaceAlbumArt.Location = new System.Drawing.Point(16, 40);
			this.m_replaceAlbumArt.Name = "m_replaceAlbumArt";
			this.m_replaceAlbumArt.Size = new System.Drawing.Size(382, 18);
			this.m_replaceAlbumArt.TabIndex = 4;
			this.m_replaceAlbumArt.Text = "Apply AlbumArtLarge.jpg / Folder.jpg as new embedded Album Art image";
			this.m_replaceAlbumArt.UseVisualStyleBackColor = true;
			this.m_replaceAlbumArt.CheckedChanged += new System.EventHandler(this.OnAddArtworkChanged);
			this.m_replaceAlbumArt.EnabledChanged += new System.EventHandler(this.OnAddArtworkChanged);
			// 
			// m_removeAlbumArt
			// 
			this.m_removeAlbumArt.AutoSize = true;
			this.m_removeAlbumArt.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_removeAlbumArt.Location = new System.Drawing.Point(16, 20);
			this.m_removeAlbumArt.Name = "m_removeAlbumArt";
			this.m_removeAlbumArt.Size = new System.Drawing.Size(250, 18);
			this.m_removeAlbumArt.TabIndex = 3;
			this.m_removeAlbumArt.Text = "Remove existing embedded Album Art images";
			this.m_removeAlbumArt.UseVisualStyleBackColor = true;
			this.m_removeAlbumArt.CheckedChanged += new System.EventHandler(this.OnRemoveArtworkChanged);
			// 
			// m_browseForMediaFolder
			// 
			this.m_browseForMediaFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_browseForMediaFolder.Location = new System.Drawing.Point(784, 28);
			this.m_browseForMediaFolder.Name = "m_browseForMediaFolder";
			this.m_browseForMediaFolder.Size = new System.Drawing.Size(24, 22);
			this.m_browseForMediaFolder.TabIndex = 1;
			this.m_browseForMediaFolder.Text = "...";
			this.m_browseForMediaFolder.UseVisualStyleBackColor = true;
			this.m_browseForMediaFolder.Click += new System.EventHandler(this.OnBrowseForLibraryLocation);
			// 
			// m_staticLibraryLocation
			// 
			this.m_staticLibraryLocation.AutoSize = true;
			this.m_staticLibraryLocation.Location = new System.Drawing.Point(12, 8);
			this.m_staticLibraryLocation.Name = "m_staticLibraryLocation";
			this.m_staticLibraryLocation.Size = new System.Drawing.Size(83, 13);
			this.m_staticLibraryLocation.TabIndex = 1;
			this.m_staticLibraryLocation.Text = "Library Location";
			// 
			// m_mediaFolder
			// 
			this.m_mediaFolder.Location = new System.Drawing.Point(12, 28);
			this.m_mediaFolder.Name = "m_mediaFolder";
			this.m_mediaFolder.Size = new System.Drawing.Size(768, 21);
			this.m_mediaFolder.TabIndex = 0;
			this.m_mediaFolder.TextChanged += new System.EventHandler(this.OnLibraryLocationChanged);
			// 
			// m_clean
			// 
			this.m_clean.Enabled = false;
			this.m_clean.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_clean.Location = new System.Drawing.Point(736, 348);
			this.m_clean.Name = "m_clean";
			this.m_clean.Size = new System.Drawing.Size(75, 23);
			this.m_clean.TabIndex = 6;
			this.m_clean.Text = "Process";
			this.m_clean.UseVisualStyleBackColor = true;
			this.m_clean.Click += new System.EventHandler(this.OnClean);
			// 
			// m_currentFolder
			// 
			this.m_currentFolder.AutoEllipsis = true;
			this.m_currentFolder.Location = new System.Drawing.Point(12, 352);
			this.m_currentFolder.Name = "m_currentFolder";
			this.m_currentFolder.Size = new System.Drawing.Size(716, 16);
			this.m_currentFolder.TabIndex = 3;
			// 
			// m_validationGroup
			// 
			this.m_validationGroup.Controls.Add(this.m_verifyGenresCDDBCompliant);
			this.m_validationGroup.Controls.Add(this.m_verifyNoVariousArtistAuthors);
			this.m_validationGroup.Controls.Add(this.m_checkFileNamesConformant);
			this.m_validationGroup.Controls.Add(this.m_verifyArtworkExists);
			this.m_validationGroup.Controls.Add(this.m_validateTrackNumbers);
			this.m_validationGroup.Controls.Add(this.m_validateTagsAgainstFolder);
			this.m_validationGroup.Location = new System.Drawing.Point(8, 60);
			this.m_validationGroup.Name = "m_validationGroup";
			this.m_validationGroup.Size = new System.Drawing.Size(352, 144);
			this.m_validationGroup.TabIndex = 7;
			this.m_validationGroup.TabStop = false;
			this.m_validationGroup.Text = "Validation";
			// 
			// m_verifyGenresCDDBCompliant
			// 
			this.m_verifyGenresCDDBCompliant.AutoSize = true;
			this.m_verifyGenresCDDBCompliant.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_verifyGenresCDDBCompliant.Location = new System.Drawing.Point(16, 120);
			this.m_verifyGenresCDDBCompliant.Name = "m_verifyGenresCDDBCompliant";
			this.m_verifyGenresCDDBCompliant.Size = new System.Drawing.Size(332, 18);
			this.m_verifyGenresCDDBCompliant.TabIndex = 10;
			this.m_verifyGenresCDDBCompliant.Text = "Verify track Genres comply with contents of genre-mappings.dat";
			this.m_verifyGenresCDDBCompliant.UseVisualStyleBackColor = true;
			this.m_verifyGenresCDDBCompliant.CheckedChanged += new System.EventHandler(this.OnValidateTrackGenresChanged);
			// 
			// m_verifyNoVariousArtistAuthors
			// 
			this.m_verifyNoVariousArtistAuthors.AutoSize = true;
			this.m_verifyNoVariousArtistAuthors.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_verifyNoVariousArtistAuthors.Location = new System.Drawing.Point(16, 100);
			this.m_verifyNoVariousArtistAuthors.Name = "m_verifyNoVariousArtistAuthors";
			this.m_verifyNoVariousArtistAuthors.Size = new System.Drawing.Size(314, 18);
			this.m_verifyNoVariousArtistAuthors.TabIndex = 9;
			this.m_verifyNoVariousArtistAuthors.Text = "Check for missing, \'Various Artists\' or \'Soundtrack\' Artist tags";
			this.m_verifyNoVariousArtistAuthors.UseVisualStyleBackColor = true;
			this.m_verifyNoVariousArtistAuthors.CheckedChanged += new System.EventHandler(this.OnValidateAuthorTagsChanged);
			// 
			// m_checkFileNamesConformant
			// 
			this.m_checkFileNamesConformant.AutoSize = true;
			this.m_checkFileNamesConformant.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_checkFileNamesConformant.Location = new System.Drawing.Point(16, 80);
			this.m_checkFileNamesConformant.Name = "m_checkFileNamesConformant";
			this.m_checkFileNamesConformant.Size = new System.Drawing.Size(309, 18);
			this.m_checkFileNamesConformant.TabIndex = 8;
			this.m_checkFileNamesConformant.Text = "Verify track file names are conformant (\"01 Song Title.xxx\")";
			this.m_checkFileNamesConformant.UseVisualStyleBackColor = true;
			this.m_checkFileNamesConformant.CheckedChanged += new System.EventHandler(this.OnValidateTrackFileNames);
			// 
			// m_verifyArtworkExists
			// 
			this.m_verifyArtworkExists.AutoSize = true;
			this.m_verifyArtworkExists.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_verifyArtworkExists.Location = new System.Drawing.Point(16, 60);
			this.m_verifyArtworkExists.Name = "m_verifyArtworkExists";
			this.m_verifyArtworkExists.Size = new System.Drawing.Size(265, 18);
			this.m_verifyArtworkExists.TabIndex = 7;
			this.m_verifyArtworkExists.Text = "Verify existance of Folder.jpg in each album folder";
			this.m_verifyArtworkExists.UseVisualStyleBackColor = true;
			this.m_verifyArtworkExists.CheckedChanged += new System.EventHandler(this.OnValidateAlbumArtChanged);
			// 
			// m_validateTrackNumbers
			// 
			this.m_validateTrackNumbers.AutoSize = true;
			this.m_validateTrackNumbers.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_validateTrackNumbers.Location = new System.Drawing.Point(16, 40);
			this.m_validateTrackNumbers.Name = "m_validateTrackNumbers";
			this.m_validateTrackNumbers.Size = new System.Drawing.Size(281, 18);
			this.m_validateTrackNumbers.TabIndex = 6;
			this.m_validateTrackNumbers.Text = "Check for duplicate or invalid track numbers / names";
			this.m_validateTrackNumbers.UseVisualStyleBackColor = true;
			this.m_validateTrackNumbers.CheckedChanged += new System.EventHandler(this.OnValidateTrackNumbersChanged);
			// 
			// m_validateTagsAgainstFolder
			// 
			this.m_validateTagsAgainstFolder.AutoSize = true;
			this.m_validateTagsAgainstFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_validateTagsAgainstFolder.Location = new System.Drawing.Point(16, 20);
			this.m_validateTagsAgainstFolder.Name = "m_validateTagsAgainstFolder";
			this.m_validateTagsAgainstFolder.Size = new System.Drawing.Size(332, 18);
			this.m_validateTagsAgainstFolder.TabIndex = 5;
			this.m_validateTagsAgainstFolder.Text = "Validate Album Name and Album Artist tags against folder layout";
			this.m_validateTagsAgainstFolder.UseVisualStyleBackColor = true;
			this.m_validateTagsAgainstFolder.CheckedChanged += new System.EventHandler(this.OnValidateAlbumTagsChanged);
			// 
			// m_selectTypical
			// 
			this.m_selectTypical.AutoSize = true;
			this.m_selectTypical.Location = new System.Drawing.Point(688, 326);
			this.m_selectTypical.Name = "m_selectTypical";
			this.m_selectTypical.Size = new System.Drawing.Size(70, 13);
			this.m_selectTypical.TabIndex = 8;
			this.m_selectTypical.TabStop = true;
			this.m_selectTypical.Text = "Typical Clean";
			this.m_selectTypical.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSelectAllSafeOptions);
			// 
			// m_clearAllSafe
			// 
			this.m_clearAllSafe.AutoSize = true;
			this.m_clearAllSafe.Location = new System.Drawing.Point(780, 326);
			this.m_clearAllSafe.Name = "m_clearAllSafe";
			this.m_clearAllSafe.Size = new System.Drawing.Size(32, 13);
			this.m_clearAllSafe.TabIndex = 9;
			this.m_clearAllSafe.TabStop = true;
			this.m_clearAllSafe.Text = "Clear";
			this.m_clearAllSafe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClearAllOptions);
			// 
			// m_replayGainGroup
			// 
			this.m_replayGainGroup.Controls.Add(this.m_gainVeryHighRadio);
			this.m_replayGainGroup.Controls.Add(this.m_rgainPreventClip);
			this.m_replayGainGroup.Controls.Add(this.m_rgainModeGroup);
			this.m_replayGainGroup.Controls.Add(this.m_gainHighRadio);
			this.m_replayGainGroup.Controls.Add(this.m_gainMediumRadio);
			this.m_replayGainGroup.Controls.Add(this.m_gainLowRadio);
			this.m_replayGainGroup.Controls.Add(this.m_applyReplayGain);
			this.m_replayGainGroup.Location = new System.Drawing.Point(8, 208);
			this.m_replayGainGroup.Name = "m_replayGainGroup";
			this.m_replayGainGroup.Size = new System.Drawing.Size(352, 136);
			this.m_replayGainGroup.TabIndex = 10;
			this.m_replayGainGroup.TabStop = false;
			this.m_replayGainGroup.Text = "Replay Gain";
			// 
			// m_gainVeryHighRadio
			// 
			this.m_gainVeryHighRadio.AutoSize = true;
			this.m_gainVeryHighRadio.Enabled = false;
			this.m_gainVeryHighRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_gainVeryHighRadio.Location = new System.Drawing.Point(224, 40);
			this.m_gainVeryHighRadio.Name = "m_gainVeryHighRadio";
			this.m_gainVeryHighRadio.Size = new System.Drawing.Size(65, 18);
			this.m_gainVeryHighRadio.TabIndex = 16;
			this.m_gainVeryHighRadio.Text = "99.2dB";
			this.m_gainVeryHighRadio.UseVisualStyleBackColor = true;
			// 
			// m_rgainPreventClip
			// 
			this.m_rgainPreventClip.AutoSize = true;
			this.m_rgainPreventClip.Checked = true;
			this.m_rgainPreventClip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_rgainPreventClip.Enabled = false;
			this.m_rgainPreventClip.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_rgainPreventClip.Location = new System.Drawing.Point(32, 60);
			this.m_rgainPreventClip.Name = "m_rgainPreventClip";
			this.m_rgainPreventClip.Size = new System.Drawing.Size(284, 18);
			this.m_rgainPreventClip.TabIndex = 15;
			this.m_rgainPreventClip.Text = "Prevent clipping by automatically reducing Gain value";
			this.m_rgainPreventClip.UseVisualStyleBackColor = true;
			// 
			// m_rgainModeGroup
			// 
			this.m_rgainModeGroup.Controls.Add(this.m_rgainTracks);
			this.m_rgainModeGroup.Controls.Add(this.m_rgainAlbum);
			this.m_rgainModeGroup.Enabled = false;
			this.m_rgainModeGroup.Location = new System.Drawing.Point(28, 80);
			this.m_rgainModeGroup.Name = "m_rgainModeGroup";
			this.m_rgainModeGroup.Size = new System.Drawing.Size(308, 44);
			this.m_rgainModeGroup.TabIndex = 14;
			this.m_rgainModeGroup.TabStop = false;
			this.m_rgainModeGroup.Text = "Analysis Mode";
			// 
			// m_rgainTracks
			// 
			this.m_rgainTracks.AutoSize = true;
			this.m_rgainTracks.Checked = true;
			this.m_rgainTracks.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_rgainTracks.Location = new System.Drawing.Point(8, 18);
			this.m_rgainTracks.Name = "m_rgainTracks";
			this.m_rgainTracks.Size = new System.Drawing.Size(149, 18);
			this.m_rgainTracks.TabIndex = 15;
			this.m_rgainTracks.TabStop = true;
			this.m_rgainTracks.Text = "Radio (Individual Tracks)";
			this.m_rgainTracks.UseVisualStyleBackColor = true;
			// 
			// m_rgainAlbum
			// 
			this.m_rgainAlbum.AutoSize = true;
			this.m_rgainAlbum.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_rgainAlbum.Location = new System.Drawing.Point(160, 18);
			this.m_rgainAlbum.Name = "m_rgainAlbum";
			this.m_rgainAlbum.Size = new System.Drawing.Size(148, 18);
			this.m_rgainAlbum.TabIndex = 14;
			this.m_rgainAlbum.Text = "Audiophile (Entire Album)";
			this.m_rgainAlbum.UseVisualStyleBackColor = true;
			// 
			// m_gainHighRadio
			// 
			this.m_gainHighRadio.AutoSize = true;
			this.m_gainHighRadio.Checked = true;
			this.m_gainHighRadio.Enabled = false;
			this.m_gainHighRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_gainHighRadio.Location = new System.Drawing.Point(160, 40);
			this.m_gainHighRadio.Name = "m_gainHighRadio";
			this.m_gainHighRadio.Size = new System.Drawing.Size(65, 18);
			this.m_gainHighRadio.TabIndex = 13;
			this.m_gainHighRadio.TabStop = true;
			this.m_gainHighRadio.Text = "95.8dB";
			this.m_gainHighRadio.UseVisualStyleBackColor = true;
			// 
			// m_gainMediumRadio
			// 
			this.m_gainMediumRadio.AutoSize = true;
			this.m_gainMediumRadio.Enabled = false;
			this.m_gainMediumRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_gainMediumRadio.Location = new System.Drawing.Point(96, 40);
			this.m_gainMediumRadio.Name = "m_gainMediumRadio";
			this.m_gainMediumRadio.Size = new System.Drawing.Size(65, 18);
			this.m_gainMediumRadio.TabIndex = 12;
			this.m_gainMediumRadio.Text = "92.4dB";
			this.m_gainMediumRadio.UseVisualStyleBackColor = true;
			// 
			// m_gainLowRadio
			// 
			this.m_gainLowRadio.AutoSize = true;
			this.m_gainLowRadio.Enabled = false;
			this.m_gainLowRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_gainLowRadio.Location = new System.Drawing.Point(32, 40);
			this.m_gainLowRadio.Name = "m_gainLowRadio";
			this.m_gainLowRadio.Size = new System.Drawing.Size(65, 18);
			this.m_gainLowRadio.TabIndex = 11;
			this.m_gainLowRadio.Text = "89.0dB";
			this.m_gainLowRadio.UseVisualStyleBackColor = true;
			// 
			// m_applyReplayGain
			// 
			this.m_applyReplayGain.AutoSize = true;
			this.m_applyReplayGain.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_applyReplayGain.Location = new System.Drawing.Point(16, 20);
			this.m_applyReplayGain.Name = "m_applyReplayGain";
			this.m_applyReplayGain.Size = new System.Drawing.Size(311, 18);
			this.m_applyReplayGain.TabIndex = 10;
			this.m_applyReplayGain.Text = "Apply Replay Gain to MP3 Albums (may take several hours)";
			this.m_applyReplayGain.UseVisualStyleBackColor = true;
			this.m_applyReplayGain.CheckedChanged += new System.EventHandler(this.OnReplayGainChanged);
			// 
			// m_selectAllValidations
			// 
			this.m_selectAllValidations.AutoSize = true;
			this.m_selectAllValidations.Location = new System.Drawing.Point(584, 326);
			this.m_selectAllValidations.Name = "m_selectAllValidations";
			this.m_selectAllValidations.Size = new System.Drawing.Size(89, 13);
			this.m_selectAllValidations.TabIndex = 11;
			this.m_selectAllValidations.TabStop = true;
			this.m_selectAllValidations.Text = "Typical Validation";
			this.m_selectAllValidations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSelectAllValidations);
			// 
			// m_scanGroup
			// 
			this.m_scanGroup.Controls.Add(this.m_scanAudioStream);
			this.m_scanGroup.Location = new System.Drawing.Point(368, 268);
			this.m_scanGroup.Name = "m_scanGroup";
			this.m_scanGroup.Size = new System.Drawing.Size(444, 48);
			this.m_scanGroup.TabIndex = 12;
			this.m_scanGroup.TabStop = false;
			this.m_scanGroup.Text = "File Verification";
			// 
			// m_scanAudioStream
			// 
			this.m_scanAudioStream.AutoSize = true;
			this.m_scanAudioStream.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_scanAudioStream.Location = new System.Drawing.Point(16, 20);
			this.m_scanAudioStream.Name = "m_scanAudioStream";
			this.m_scanAudioStream.Size = new System.Drawing.Size(368, 18);
			this.m_scanAudioStream.TabIndex = 10;
			this.m_scanAudioStream.Text = "Scan entire track audio stream (may take several hours or several days)";
			this.m_scanAudioStream.UseVisualStyleBackColor = true;
			this.m_scanAudioStream.CheckedChanged += new System.EventHandler(this.OnScanAudioStreamChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(820, 383);
			this.Controls.Add(this.m_scanGroup);
			this.Controls.Add(this.m_selectAllValidations);
			this.Controls.Add(this.m_replayGainGroup);
			this.Controls.Add(this.m_clearAllSafe);
			this.Controls.Add(this.m_selectTypical);
			this.Controls.Add(this.m_validationGroup);
			this.Controls.Add(this.m_currentFolder);
			this.Controls.Add(this.m_clean);
			this.Controls.Add(this.m_optionsGroup);
			this.Controls.Add(this.m_browseForMediaFolder);
			this.Controls.Add(this.m_mediaFolder);
			this.Controls.Add(this.m_staticLibraryLocation);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Windows Media Player Library Cleanup Tool {0}";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.m_optionsGroup.ResumeLayout(false);
			this.m_optionsGroup.PerformLayout();
			this.m_validationGroup.ResumeLayout(false);
			this.m_validationGroup.PerformLayout();
			this.m_replayGainGroup.ResumeLayout(false);
			this.m_replayGainGroup.PerformLayout();
			this.m_rgainModeGroup.ResumeLayout(false);
			this.m_rgainModeGroup.PerformLayout();
			this.m_scanGroup.ResumeLayout(false);
			this.m_scanGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog m_folderBrowser;
		private System.Windows.Forms.GroupBox m_optionsGroup;
		private System.Windows.Forms.Label m_staticLibraryLocation;
		private System.Windows.Forms.TextBox m_mediaFolder;
		private System.Windows.Forms.Button m_browseForMediaFolder;
		private System.Windows.Forms.CheckBox m_removeAlbumArt;
		private System.Windows.Forms.Button m_clean;
		private System.Windows.Forms.CheckBox m_replaceAlbumArt;
		private System.Windows.Forms.Label m_currentFolder;
		private System.Windows.Forms.CheckBox m_removeCollectionTags;
		private System.Windows.Forms.GroupBox m_validationGroup;
		private System.Windows.Forms.CheckBox m_validateTrackNumbers;
		private System.Windows.Forms.CheckBox m_validateTagsAgainstFolder;
		private System.Windows.Forms.CheckBox m_generateMissingAlbumTags;
		private System.Windows.Forms.CheckBox m_verifyArtworkExists;
		private System.Windows.Forms.CheckBox m_checkFileNamesConformant;
		private System.Windows.Forms.CheckBox m_removeVolumeLevelingTags;
		private System.Windows.Forms.CheckBox m_replaceArtistWithAlbumArtist;
		private System.Windows.Forms.CheckBox m_verifyNoVariousArtistAuthors;
		private System.Windows.Forms.CheckBox m_generateMissingWMTrackNumberTags;
		private System.Windows.Forms.LinkLabel m_selectTypical;
		private System.Windows.Forms.LinkLabel m_clearAllSafe;
		private System.Windows.Forms.GroupBox m_replayGainGroup;
		private System.Windows.Forms.RadioButton m_gainHighRadio;
		private System.Windows.Forms.RadioButton m_gainMediumRadio;
		private System.Windows.Forms.RadioButton m_gainLowRadio;
		private System.Windows.Forms.CheckBox m_applyReplayGain;
		private System.Windows.Forms.LinkLabel m_selectAllValidations;
		private System.Windows.Forms.GroupBox m_scanGroup;
		private System.Windows.Forms.CheckBox m_scanAudioStream;
		private System.Windows.Forms.CheckBox m_rgainPreventClip;
		private System.Windows.Forms.GroupBox m_rgainModeGroup;
		private System.Windows.Forms.RadioButton m_rgainTracks;
		private System.Windows.Forms.RadioButton m_rgainAlbum;
		private System.Windows.Forms.RadioButton m_gainVeryHighRadio;
		private System.Windows.Forms.CheckBox m_undoReplayGainChanges;
		private System.Windows.Forms.CheckBox m_verifyGenresCDDBCompliant;
		private System.Windows.Forms.CheckBox m_rollupGracenoteGenres;
	}
}