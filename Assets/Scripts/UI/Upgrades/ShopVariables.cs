using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class ShopVariables : MonoBehaviour, IDataPersistence
    {
        private static ShopVariables _instance;

        public static ShopVariables instance
        {
            get
            {
            return _instance;
            }
        }


        public int fireGold;
        public int waterGold;
        public int windGold;
        public int natureGold;
        public int thunderGold;
        public int iceGold;
        public int earthGold;
        public int acidGold;
        public int holyGold;
        public int darkGold; 
        
        public float fireShopDamage;
        public float waterShopDamage;
        public float windShopDamage;
        public float earthShopDamage;
        public float iceShopDamage;
        public float thunderShopDamage;
        public float natureShopDamage;
        public float acidShopDamage;
        public float holyShopDamage;
        public float darkShopDamage;

        public float fireProgress;
        public float waterProgress;
        public float earthProgress;
        public float windProgress;
        public float iceProgress;
        public float thunderProgress;
        public float natureProgress;
        public float acidProgress;
        public float holyProgress;
        public float darkProgress;




        public int swordGold;
        public int polearmGold;
        public int heavyWeaponryGold;
        public int longRangeGold;

        public float swordShopDamage;
        public float polearmShopDamage;
        public float heavyWeaponryShopDamage;
        public float longRangeShopDamage;

        public float swordProgress;
        public float polearmProgress;
        public float heavyWeaponryProgress;
        public float longRangeProgress;



        private void Awake() {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }



        public void SaveData (GameData data) 
        {
            data.acidShopDamage = this.acidShopDamage;
            data.natureShopDamage = this.natureShopDamage;
            data.thunderShopDamage = this.thunderShopDamage;
            data.iceShopDamage = this.iceShopDamage;
            data.earthShopDamage = this.earthShopDamage;
            data.windShopDamage = this.windShopDamage;
            data.fireShopDamage = this.fireShopDamage;
            data.waterShopDamage = this.waterShopDamage;
            data.holyShopDamage = this.holyShopDamage;
            data.darkShopDamage = this.darkShopDamage;

            data.acidGold = this.acidGold;
            data.fireGold = this.fireGold;
            data.waterGold = this.waterGold;
            data.windGold = this.windGold;
            data.natureGold = this.natureGold;
            data.thunderGold = this.thunderGold;
            data.iceGold = this.iceGold;
            data.earthGold = this.earthGold;
            data.holyGold = this.holyGold;
            data.darkGold = this.darkGold;

            data.acidProgress = this.acidProgress;
            data.fireProgress = this.fireProgress;
            data.earthProgress = this.earthProgress;
            data.darkProgress = this.darkProgress;
            data.holyProgress = this.holyProgress;
            data.waterProgress = this.waterProgress;
            data.windProgress = this.windProgress;
            data.iceProgress = this.iceProgress;
            data.thunderProgress = this.thunderProgress;
            data.natureProgress = this.natureProgress;




            data.swordShopDamage = this.swordShopDamage;
            data.polearmShopDamage = this.polearmShopDamage;
            data.heavyWeaponryShopDamage = this.heavyWeaponryShopDamage;
            data.longRangeShopDamage = this.longRangeShopDamage;

            data.swordGold = this.swordGold;
            data.polearmGold = this.polearmGold;
            data.heavyWeaponryGold = this.heavyWeaponryGold;
            data.longRangeGold = this.longRangeGold;

            data.swordProgress = this.swordProgress;
            data.polearmProgress = this.polearmProgress;
            data.heavyWeaponryProgress = this.heavyWeaponryProgress;
            data.longRangeProgress = this.longRangeProgress;
        }

        public void LoadData (GameData data) 
        {
            this.fireGold = data.fireGold;
            this.waterGold = data.waterGold;
            this.windGold = data.windGold;
            this.natureGold = data.natureGold;
            this.thunderGold = data.thunderGold;
            this.iceGold = data.iceGold;
            this.earthGold = data.earthGold;
            this.acidGold = data.acidGold;
            this.holyGold = data.holyGold;
            this.darkGold = data.darkGold; 
            
            this.fireShopDamage = data.fireShopDamage;
            this.waterShopDamage = data.waterShopDamage;
            this.windShopDamage = data.windShopDamage;
            this.earthShopDamage = data.earthShopDamage;
            this.iceShopDamage = data.iceShopDamage;
            this.thunderShopDamage = data.thunderShopDamage;
            this.natureShopDamage = data.natureShopDamage;
            this.acidShopDamage = data.acidShopDamage;
            this.holyShopDamage = data.holyShopDamage;
            this.darkShopDamage = data.darkShopDamage;

            this.fireProgress = data.fireProgress;
            this.waterProgress = data.waterProgress;
            this.earthProgress = data.earthProgress;
            this.windProgress = data.windProgress;
            this.iceProgress = data.iceProgress;
            this.thunderProgress = data.thunderProgress;
            this.natureProgress = data.natureProgress;
            this.acidProgress = data.acidProgress;
            this.holyProgress = data.holyProgress;
            this.darkProgress = data.darkProgress;



            this.swordGold = data.swordGold;
            this.polearmGold = data.polearmGold;
            this.heavyWeaponryGold = data.heavyWeaponryGold;
            this.longRangeGold = data.longRangeGold;

            this.swordShopDamage = data.swordShopDamage;
            this.polearmShopDamage = data.polearmShopDamage;
            this.heavyWeaponryShopDamage = data.heavyWeaponryShopDamage;
            this.longRangeShopDamage = data.longRangeShopDamage;

            this.swordProgress = data.swordProgress;
            this.polearmProgress = data.polearmProgress;
            this.heavyWeaponryProgress = data.heavyWeaponryProgress;
            this.longRangeProgress = data.longRangeProgress;
        }

    }
}
