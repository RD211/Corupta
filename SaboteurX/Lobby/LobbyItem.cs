using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickType;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using FireSharp.Config;

namespace SaboteurX
{
    public partial class LobbyItem : UserControl
    {
        KeyValuePair<string, LobbyModel> lobbyData = new KeyValuePair<string, LobbyModel>();
        Label selectedLabel;
        readonly GameSelectorScreen fatherForm;
        bool loading = false;
        public LobbyItem(KeyValuePair<string, LobbyModel> lobby, GameSelectorScreen father)
        {
            InitializeComponent();
            this.lobbyData = lobby;
            this.fatherForm = father;
            LoadPlayerImages();
            this.BackColor = GlobalSettings.mainColor;
            this.ChangeFormColor();
        }
        private void LoadPlayerImages()
        {
            for(int i = 0;i<lobbyData.Value.Players.Count;i++)
            {
                PictureBox pbox=null;
                switch(i)
                {
                    case 0:
                        pbox = pbox_player_0;
                        break;
                    case 1:
                        pbox = pbox_player_1;
                        break;
                    case 2:
                        pbox = pbox_player_2;
                        break;
                    case 3:
                        pbox = pbox_player_3;
                        break;
                    case 4:
                        pbox = pbox_player_4;
                        break;
                    case 5:
                        pbox = pbox_player_5;
                        break;
                    case 6:
                        pbox = pbox_player_6;
                        break;
                    case 7:
                        pbox = pbox_player_7;
                        break;
                }
                pbox.Image = new PlayerInformation(lobbyData.Value.Players[i]).GetPictureBitmap(600,600);
            }
        }
        private void LobbyItem_Load(object sender, EventArgs e)
        {
            this.lbl_join.Text = this.lbl_join.Tag.ToString().Split(';')[0].ToAsciiArt();
        }

        private void Lbl_join_MouseEnter(object sender, EventArgs e)
        {
            this.selectedLabel = (Label)sender;
            Timer_animation_Tick(null, null);
        }

        private void Timer_animation_Tick(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                var tag = selectedLabel.Tag.ToString().Split(';');
                if (tag[1] == "NO")
                {
                    selectedLabel.Text = ("-" + tag[0] + "-").ToAsciiArt();
                    selectedLabel.Tag = tag[0] + ";YES";
                }
                else
                {
                    selectedLabel.Text = (tag[0]).ToAsciiArt();
                    selectedLabel.Tag = tag[0] + ";NO";
                }
            }
        }

        private void Lbl_join_MouseLeave(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                this.selectedLabel.Text = this.selectedLabel.Tag.ToString().Split(';')[0].ToAsciiArt();
                this.selectedLabel.Tag = $"{this.selectedLabel.Tag.ToString().Split(';')[0]};NO";
                selectedLabel = null;
            }

        }

        private void Lbl_join_ClickAsync(object sender, EventArgs e)
        {
            if (!loading)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
                JoinLobby();
            }
        }
        private async void JoinLobby()
        {
            loading = true;
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            lobbyData.Value.Players.Add(fatherForm.information.ToCompressedString());
            await client.UpdateAsync($"lobbies/{lobbyData.Key}", lobbyData.Value);
            var waitingRoom = new LobbyWaitingRoom(lobbyData, fatherForm.information);
            this.fatherForm.Hide();
            if (waitingRoom.ShowDialog() == DialogResult.OK)
            {
                this.fatherForm.DialogResult = DialogResult.OK;
                this.fatherForm.Close();
            }
            loading = false;
        }


        Label nameHelperLabel = null;
        private void Avatar_MouseEnter(object sender, EventArgs e)
        {
            int playerId = int.Parse(((PictureBox)sender).Tag.ToString());
            if (playerId >= lobbyData.Value.Players.Count)
                return;
            if (nameHelperLabel == null)
            {
                nameHelperLabel = new Label()
                {
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 15f, FontStyle.Regular),
                };
                this.Controls.Add(nameHelperLabel);
            }
            nameHelperLabel.Text = lobbyData.Value.Players[playerId].Split(';')[0];
            nameHelperLabel.Location = ((PictureBox)sender).Location;
            nameHelperLabel.BringToFront();
        }

        private void Avatar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(nameHelperLabel);
            nameHelperLabel = null;
        }
    }
}
