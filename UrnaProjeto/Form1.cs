namespace UrnaProjeto
{
    public partial class Form1 : Form
    {
        // Vari�veis para armazenar os votos
        private int votosCristiano = 0;  // Votos para Cristiano Ronaldo
        private int votosMessi = 0;      // Votos para Messi
        private int votosNeymar = 0;     // Votos para Neymar
        private string votoAtual = "";   // Para armazenar o voto atual do usu�rio

        public Form1()
        {
            InitializeComponent();
        }

        // Este m�todo � chamado quando o formul�rio � carregado, inicializando o estado da urna
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetarUrna();
        }

        // Fun��es para adicionar d�gitos aos votos, chamam o m�todo AdicionarDigito passando o n�mero correspondente
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

        // Fun��o para corrigir o voto atual, limpa o texto e reseta o estado
        private void btnCorrige_Click(object sender, EventArgs e)
        {
            votoAtual = "";  // Limpa o voto atual
            tex_Votos.Clear();  // Limpa o campo de texto que exibe o voto
            pictureBoxCandidato.Image = Properties.Resources.voteaqui; // Reseta a imagem para a padr�o
            MessageBox.Show("Voto corrigido. Escolha novamente.");
        }

        // Este m�todo confirma o voto, verificando qual foi o n�mero digitado
        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(votoAtual))
            {
                MessageBox.Show("Nenhum voto foi registrado. Por favor, digite seu voto.");
                return;
            }

            // Verifica qual n�mero foi digitado e incrementa o voto do candidato correspondente
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
                    MessageBox.Show("N�mero inv�lido! Por favor, insira um n�mero v�lido.");
                    ResetarUrna();  // Reseta a urna caso o n�mero n�o seja v�lido
                    return;
            }

            // Verifica se algum candidato atingiu a quantidade de votos necess�ria para ganhar
            VerificarVencedor(true);
            AtualizarLabelsVotos();  // Atualiza os votos na tela
            ResetarUrna();  // Reseta a urna para o pr�ximo voto
        }

        // Este m�todo verifica automaticamente se algum candidato venceu com 6 votos
        private void VerificarVencedorAutomatico()
        {
            if (votosCristiano == 6)
            {
                MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos! (Vota��o encerrada automaticamente)");
                ResetarVotos();  // Reseta os votos ap�s a vit�ria
            }
            else if (votosMessi == 6)
            {
                MessageBox.Show($"Messi venceu com {votosMessi} votos! (Vota��o encerrada automaticamente)");
                ResetarVotos();  // Reseta os votos ap�s a vit�ria
            }
            else if (votosNeymar == 6)
            {
                MessageBox.Show($"Neymar venceu com {votosNeymar} votos! (Vota��o encerrada automaticamente)");
                ResetarVotos();  // Reseta os votos ap�s a vit�ria
            }
        }

        // Este m�todo verifica se algum candidato atingiu 6 votos e se sim, encerra a vota��o
        private void VerificarVencedor(bool finalAutomatica)
        {
            if (votosCristiano >= 6)
            {
                MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos! {(finalAutomatica ? "(Vota��o encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
            else if (votosMessi >= 6)
            {
                MessageBox.Show($"Messi venceu com {votosMessi} votos! {(finalAutomatica ? "(Vota��o encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
            else if (votosNeymar >= 6)
            {
                MessageBox.Show($"Neymar venceu com {votosNeymar} votos! {(finalAutomatica ? "(Vota��o encerrada automaticamente)" : "")}");
                ResetarVotos();
            }
        }

        // Atualiza os labels na interface com os votos acumulados
        private void AtualizarLabelsVotos()
        {
            // Atualiza os votos de cada candidato na interface
            votos_cristiano.Text = votosCristiano.ToString(); // Atualiza o n�mero de votos de Cristiano
            votos_messi.Text = votosMessi.ToString();         // Atualiza o n�mero de votos de Messi
            votos_neymar.Text = votosNeymar.ToString();       // Atualiza o n�mero de votos de Neymar
        }

        // Reseta o estado da urna, limpando o voto atual e os campos na interface
        private void ResetarUrna()
        {
            votoAtual = "";  // Limpa o voto atual
            tex_Votos.Clear(); // Limpa o campo de texto de votos
            pictureBoxCandidato.Image = Properties.Resources.voteaqui; // Reseta a imagem padr�o
        }

        // Adiciona um d�gito ao voto atual e atualiza a interface com a imagem correspondente
        private void AdicionarDigito(string digito)
        {
            votoAtual += digito;  // Adiciona o d�gito ao voto
            tex_Votos.Text = votoAtual; // Atualiza o campo de texto com o voto atual

            // Caminho das imagens dos candidatos
            string imagePath = Path.Combine(Application.StartupPath, "Deputados");

            // Verifica o voto atual e altera a imagem para o candidato correspondente
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

        // M�todo para registrar um voto em branco
        private void btnBranco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto em branco registrado.");
            ResetarUrna();  // Reseta a urna ap�s o voto em branco
        }

        private void pictureBoxCandidato_Click(object sender, EventArgs e)
        {
            // Este evento n�o est� implementado, pode ser utilizado para futuras intera��es com a imagem
        }

        // Este m�todo exibe o resultado da elei��o ap�s a contagem dos votos
        private void btnResultadoEleicao_Click(object sender, EventArgs e)
        {
            // Verifica se todos os candidatos t�m 0 votos, indicando um empate
            if (votosCristiano == 0 && votosMessi == 0 && votosNeymar == 0)
            {
                MessageBox.Show("Empate! Todos os candidatos t�m 0 votos.");
            }
            else
            {
                int maxVotos = Math.Max(votosCristiano, Math.Max(votosMessi, votosNeymar));

                // Exibe o vencedor com o n�mero m�ximo de votos
                if (maxVotos == votosCristiano)
                    MessageBox.Show($"Cristiano Ronaldo venceu com {votosCristiano} votos!");
                else if (maxVotos == votosMessi)
                    MessageBox.Show($"Messi venceu com {votosMessi} votos!");
                else
                    MessageBox.Show($"Neymar venceu com {votosNeymar} votos!");
            }

            ResetarVotos(); // Reseta os votos ap�s exibir o resultado
        }

        // Reseta todos os votos dos candidatos
        private void ResetarVotos()
        {
            votosCristiano = 0;
            votosMessi = 0;
            votosNeymar = 0;

            AtualizarLabelsVotos();  // Atualiza os labels com os votos resetados
            MessageBox.Show("Os votos foram resetados para uma nova elei��o.");
        }
    }
}
