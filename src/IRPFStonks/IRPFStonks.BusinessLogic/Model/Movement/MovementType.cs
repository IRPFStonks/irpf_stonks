using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRPFStonks.BusinessLogic.Model.Movement
{
    /// <summary>
    /// These are the different types of moviments for each stock movement
    /// </summary>
    public enum MovementType
    {
        /// <summary>
        /// Dividendo
        /// </summary>
        Dividend,
        /// <summary>
        /// Juros Sobre Capital Próprio
        /// </summary>
        Jcp,
        /// <summary>
        /// Transferência - Liquidação
        /// </summary>
        TransferSettlement,
        /// <summary>
        /// Leilão de Fração
        /// </summary>
        FractionAuction,
        /// <summary>
        /// Cisão ou Desdobro
        /// </summary>
        StockSplit,
        /// <summary>
        /// Fração em Ativos
        /// </summary>
        AssetFraction

    }
}
