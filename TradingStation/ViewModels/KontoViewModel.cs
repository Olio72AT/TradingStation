using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingStation.Models;

namespace TradingStation.ViewModels
{
    public class KontoViewModel
    {
        //public static List<KontoViewModel> ViewModelList;
        //foreach assetKonto aK in user.AssetKontos
        //{ [do :] 
        // ViewModel modelToAdd = new ViewModel();
        //modelToAdd.id = ViewModelList.Count+1;
        //
        //modelToAdd.KontoArt = aK.KontoArt;
        //modelToAdd.KindOfAsset = aK.KontoAsset.asset.KindOfAsset;
        //modelToAdd.AssetName = ak.KontoAsset.asset.AssetName;
        //modelToAdd.AssetAmount = ak.KontoAsset.assetAmount;

        //Das da oben ist sozusagen ein on-the-fly PseudoCode-Entwurf,
        //wie wir das ViewModel populaten wuerden um es dann an eine ActionresultMethode im abschliessenden Return 
        // zu uebergeben, sodass man es dann anzeigen kann.
        //Im Falle des KontoViewModels, muessten wir es als PartialView anlegen.
        //Welche IM bzw. VOM USERVIEWMODEL-View mit einem @foreach gerendert werden wuerde.
        //Es gibt sicher auch andere Herangehensweisen, aber bei einem on-the-fly Projekt, muss man sich einfach entscheiden
        //und dann einen Ansatz verfolgen, es steht jedem Nachbearbeiter frei von vorne anzufangen und einen ganz anderen Ansatz zu verfolgen.
        //Viel Glueck.

        public int Id { get; set; }
        public int UserId { get; set; }
        public string KontoArt { get; set; }
        public KindOfAsset KindOfASset { get; set; }
        public string AssetName { get; set; }
        public decimal AssetAmount { get; set; }


        
    }

}