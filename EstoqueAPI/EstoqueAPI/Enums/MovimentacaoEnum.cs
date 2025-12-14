using System.ComponentModel;

namespace EstoqueAPI.Enums
{
    public enum MovimentacaoEnum
    {
        [Description("Operação de entrada")]
        Entrada = 1,

        [Description ("Operação de Saída")]
        Saida = 2
    }
}
