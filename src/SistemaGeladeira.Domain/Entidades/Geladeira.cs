namespace SistemaGeladeira.Domain.Entidades;

// Representa a geladeira que contém uma lista de andares
public sealed class Geladeira
{
    // Lista interna que armazena os andares da geladeira
    private readonly List<Andar> _andares;

    // Constante que define o número máximo de andares permitido na geladeira
    private const int MAX_ANDARES = 3;

    // Construtor privado para evitar a criação direta de instâncias
    // Inicializa a lista de andares
    private Geladeira() => _andares = [];

    // Método de fábrica estático para criar uma nova instância de Geladeira
    public static Geladeira CriarGeladeira() => new();

    // Método para adicionar um novo andar à geladeira
    public void CriarAndar(string descricao)
    {
        // Verifica se o número máximo de andares já foi atingido
        if (_andares.Count >= MAX_ANDARES)
            throw new Exception("Número máximo de andares atingido.");

        // Cria um novo andar e adiciona à lista de andares
        var andar = Andar.CriarAndar(_andares.Count, descricao);
        _andares.Add(andar);
    }

    // Método para adicionar um novo container a um andar específico
    public void CriarContainer(int numeroAndar, int numeroContainer)
    {
        // Obtém o andar especificado pelo número
        var andar = ObterAndar(numeroAndar);
        // Cria um novo container dentro do andar obtido
        andar.CriarContainer(numeroContainer);
    }

    // Método para adicionar um item a um container específico
    public void AdicionarItem(int numAndar, int numContainer, int posicao, Item item)
    {
        // Obtém o andar especificado pelo número
        var andar = ObterAndar(numAndar);
        // Obtém o container especificado pelo número dentro do andar
        var container = andar.ObterContainer(numContainer);
        // Adiciona o item ao container na posição especificada
        container.AdicionarItem(posicao, item);
    }

    // Método para remover um item de um container específico
    public void RemoverItem(int numAndar, int numContainer, int posicao)
    {
        // Obtém o andar especificado pelo número
        var andar = ObterAndar(numAndar);
        // Obtém o container especificado pelo número dentro do andar
        var container = andar.ObterContainer(numContainer);
        // Remove o item do container na posição especificada
        container.RemoverItem(posicao);
    }

    // Método para limpar todos os itens de um container específico
    public void LimparContainer(int numAndar, int numContainer)
    {
        // Obtém o andar especificado pelo número
        var andar = ObterAndar(numAndar);
        // Obtém o container especificado pelo número dentro do andar
        var container = andar.ObterContainer(numContainer);
        // Limpa todos os itens do container
        container.LimparContainer();
    }

    // Método para imprimir o conteúdo de todos os andares da geladeira
    public string ImprimirConteudo()
    {
        StringBuilder sb = new();
        // Itera sobre todos os andares e adiciona a impressão dos itens ao StringBuilder
        foreach (var andar in _andares)
        {
            sb.AppendLine(andar.ImprimirItens());
        }
        // Retorna a representação em string do conteúdo da geladeira
        return sb.ToString();
    }

    // Método privado para obter um andar específico pelo número
    private Andar ObterAndar(int numero)
    {
        // Verifica se o número do andar está dentro do intervalo válido
        if (numero < 0 || numero >= _andares.Count)
            throw new Exception("Número do andar inválido.");

        // Retorna o andar correspondente ao número especificado
        return _andares[numero];
    }
}
