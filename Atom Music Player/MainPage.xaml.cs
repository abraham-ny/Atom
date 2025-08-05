using Atom_Music_Player.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Atom_Music_Player
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<AudioModel> MusicList = new List<AudioModel>();
        public MainPage()
        {
            this.InitializeComponent();
            LoadAudioFiles();
            ControlsGrid.Width = mPage.Width - listGrid.Width;
            controlsStackPanel.Width = ControlsGrid.Width;
           // AudioList.ItemsSource = MusicList;
            musicProgress.Width = controlsStackPanel.Width - playingTimeElapsed.Width - playingEndTime.Width;
        }

        public void GetMusicInfo()
        {
           // Music 
        }

        private void AudioList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (AudioModel)e.ClickedItem;
            playingName.Text = clickedItem.Title;
            playingArtist.Text = clickedItem.Artist;
            playingTimeElapsed.Text = clickedItem.Duration.ToString();
            playingEndTime.Text = clickedItem.Duration.ToString();
        }

        private void musicProgress_DragLeave(object sender, DragEventArgs e)
        {
            playingTimeElapsed.Text = musicProgress.Value.ToString();
        }

        private async void LoadAudioFiles()
        {
            string df = "";
            var smsc = new List<AudioModel>();
            StorageFolder videoFolder = await KnownFolders.GetFolderForUserAsync(null, KnownFolderId.MusicLibrary);
            IReadOnlyList<StorageFile> filesList = await videoFolder.GetFilesAsync();
            var count = filesList.Count;
            StringBuilder fileCount = new StringBuilder(videoFolder.Name + " (" + count + ")\n");
            foreach (StorageFile file in filesList)
            {

                df = df + "\n" + file.Name;
                if (file.Name.EndsWith(".mp3") || file.Name.EndsWith(".wav") || file.Name.EndsWith(".ogg") || file.Name.EndsWith(".m3a") || file.Name.EndsWith(".aud"))
                {
                    smsc.Add(new AudioModel { Album = "Talk that talk", Artist = "Rihanna", Duration = 40000, Title = file.DisplayName, Year = 2013 });
                }

            }
            AudioList.ItemsSource = smsc;
        }
    }
}
