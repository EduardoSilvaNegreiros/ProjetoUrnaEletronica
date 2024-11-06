namespace UrnaProjeto
{
    public partial class Form1 : Form
    {
        // Variáveis para armazenar os votos
        private int votosCristiano = 0;
        private int votosMessi = 0;
        private int votosNeymar = 0;
        private string votoAtual = ""; // Para armazenar o voto atual do usuário

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetarUrna();
        }

        private void btn1_Click(object sender, EventArgs e) => AdicionarDigito("1");
        private void btn2_Click(object sender, EventArgs e) => AdicionarDigito("2");
        private void btn3_Click(object sender, EventArgs e) => AdicionarDigito("3");
        private void btn4_Click(object sender, EventArgs e) => AdicionarDigito("4");
        private void btn5_Click(object sender, EventArgs e) => AdicionarDigito("5");
        private void btn6_Click(object sender, EventArgs e) => AdicionarDigito("6");
        private void btn7_Click(object sender, EventArgs e) => AdicionarDigito("7");
        private void btn8_Click(object sender, EventArgs e) => AdicionarDigito("8");
        private void btn9_Click(object sender, EventArgs e) => AdicionarDigito("9");
        private void btn0_Click(object sender, EventArgs e) => AdicionarDigito("0");

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            votoAtual = "";
            tex_Votos.Clear();
            pictureBoxCandidato.Image = Properties.Resources.voteaqui;
            MessageBox.Show("Voto corrigido. Escolha novamente.");
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(votoAtual))
            {
                MessageBox.Show("Nenhum voto foi registrado. Por favor, digite seu voto.");
                return;
            }

            switch (votoAtual)
            {
                case "22":
                    votosCristiano++;
                    break;
                case "15":
                    votosMessi++;
                    break;
                case "17":
                    votosNeymar++;
                    break;
                default:
                    MessageBox.Show("Número inválido! Por favor, insira um número válido.");
                    ResetarUrna();
                    return;
            }

            VerificarVencedor(true);
            AtualizarLabelsVotos();
            ResetarUrna();
        }

        private void VerificarVencedorAutomatico()
        {
            if (votosCristiano == 6)
            {
                MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos! (Votação encerrada automaticamente)");
                ResetarVotos();
            }
            else if (votosMessi == 6)
            {
                MessageBox.Show($"Messi venceu com {votosMessi} votos! (Votação encerrada automaticamente)");
                ResetarVotos();
            }
            else if (votosNeymar == 6)
            {
                MessageBox.Show($"Neymar venceu com {votosNeymar} votos! (Votação encerrada automaticamente)");
                ResetarVotos();
            }
        }

        private void VerificarVencedor(bool finalAutomatica)
        {
            if (votosCristiano >= 6)
            {
                MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos! {(finalAutomatica ? "(Votação encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
            else if (votosMessi >= 6)
            {
                MessageBox.Show($"Messi venceu com {votosMessi} votos! {(finalAutomatica ? "(Votação encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
            else if (votosNeymar >= 6)
            {
                MessageBox.Show($"Neymar venceu com {votosNeymar} votos! {(finalAutomatica ? "(Votação encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
        }

        private void AtualizarLabelsVotos()
        {
            // Atualiza os labels com os votos acumulados
            votos_cristiano.Text = votosCristiano.ToString(); // Atualiza apenas o número de votos
            votos_messi.Text = votosMessi.ToString();         // Atualiza apenas o número de votos
            votos_neymar.Text = votosNeymar.ToString();       // Atualiza apenas o número de votos
        }

        private void ResetarUrna()
        {
            votoAtual = "";
            tex_Votos.Clear(); // Limpa o TextBox de votos
            pictureBoxCandidato.Image = Properties.Resources.voteaqui; // Reseta para a imagem padrão
        }

        private void AdicionarDigito(string digito)
        {
            votoAtual += digito;
            tex_Votos.Text = votoAtual;

            string imagePath = Path.Combine(Application.StartupPath, "Deputados");

            switch (votoAtual)
            {
                case "15":
                    pictureBoxCandidato.Image = Image.FromFile(Path.Combine(imagePath, "messi.jpg"));
                    break;
                case "17":
                    pictureBoxCandidato.Image = Image.FromFile(Path.Combine(imagePath, "neyp.jpg"));
                    break;
                case "22":
                    pictureBoxCandidato.Image = Image.FromFile(Path.Combine(imagePath, "cristiano.jpg"));
                    break;
                default:
                    pictureBoxCandidato.Image = Image.FromFile(Path.Combine(imagePath, "voteaqui.jpg"));
                    break;
            }
        }

        // Método para registrar voto em branco
        private void btnBranco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto em branco registrado.");
            ResetarUrna(); // Reseta a urna após o voto em branco
        }

        private void pictureBoxCandidato_Click(object sender, EventArgs e)
        {

        }

        private void btnResultadoEleicao_Click(object sender, EventArgs e)
        {
            // Verifica se todos os candidatos têm 0 votos
            if (votosCristiano == 0 && votosMessi == 0 && votosNeymar == 0)
            {
                MessageBox.Show("Empate! Todos os candidatos têm 0 votos.");
            }
            else
            {
                int maxVotos = Math.Max(votosCristiano, Math.Max(votosMessi, votosNeymar));

                if (maxVotos == votosCristiano)
                    MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos!");
                else if (maxVotos == votosMessi)
                    MessageBox.Show($"Messi venceu com {votosMessi} votos!");
                else
                    MessageBox.Show($"Neymar venceu com {votosNeymar} votos!");
            }

            ResetarVotos(); // Reinicia os votos após exibir o resultado
        }

        private void ResetarVotos()
        {
            votosCristiano = 0;
            votosMessi = 0;
            votosNeymar = 0;

            AtualizarLabelsVotos(); // Atualiza os rótulos de votos após o reset
            MessageBox.Show("Os votos foram resetados para uma nova eleição.");
        }
    }
}
