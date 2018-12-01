using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManSprite : MonoBehaviour {

    [System.Serializable]
    public class SpritesArchve
    {
        // WORKER
        public Sprite WorkerF;
        public Sprite WorkerM;

         // 1 TIER BUILDER
        public Sprite BuilderF;
        public Sprite BuilderM;

         // 2 TIER BUILDER
        public Sprite Builder1F;
        public Sprite Builder1M;
        public Sprite Builder2F;
        public Sprite Builder2M;
        public Sprite Builder3F;
        public Sprite Builder3M;

         // 1 TIER FARMER
        public Sprite FarmerF;
        public Sprite FarmerM;
         
         // 2 TIER FARMER
        public Sprite Farmer1F;
        public Sprite Farmer1M;
        public Sprite Farmer2F;
        public Sprite Farmer2M;
        public Sprite Farmer3F;
        public Sprite Farmer3M;
         
         // 1 TIER SOLDIER
        public Sprite SoldierF;
        public Sprite SoldierM;
         
         // 2 TIER SOLDIER
        public Sprite Soldier1F;
        public Sprite Soldier1M;
        public Sprite Soldier2F;
        public Sprite Soldier2M;
        public Sprite Soldier3F;
        public Sprite Soldier3M;
    }

    public SpritesArchve spriteArchive;
    private SpriteRenderer spriteRenderer;
    private Man man;

    // Use this for initialization
    void Start () {
        man = GetComponent<Man>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if( man.sex == Sex.male )
            spriteRenderer.sprite = spriteArchive.WorkerM;
        else
            spriteRenderer.sprite = spriteArchive.WorkerF;

    }
	
	// Update is called once per frame
	void Update () {

        switch( man.role )
        {
            case Role.worker:
                if (man.sex == Sex.male)
                    spriteRenderer.sprite = spriteArchive.WorkerM;
                else
                    spriteRenderer.sprite = spriteArchive.WorkerF;
                return;

            case Role.builder:
                switch (man.variant)
                {
                    case Variant.none:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.BuilderM;
                        else                                 
                            spriteRenderer.sprite = spriteArchive.BuilderF;
                        return;                               
                                                              
                    case Variant._1:                          
                        if (man.sex == Sex.male)              
                            spriteRenderer.sprite = spriteArchive.Builder1M;
                        else                                   
                            spriteRenderer.sprite = spriteArchive.Builder1F;
                        return;                               
                                                              
                    case Variant._2:                          
                        if (man.sex == Sex.male)              
                            spriteRenderer.sprite = spriteArchive.Builder2M;
                        else                                      
                            spriteRenderer.sprite = spriteArchive.Builder2F;
                        return;                               
                                                              
                    case Variant._3:                          
                        if (man.sex == Sex.male)              
                            spriteRenderer.sprite = spriteArchive.Builder3M;
                        else                                      
                            spriteRenderer.sprite = spriteArchive.Builder3F;
                        return;
                }
                break;

            case Role.farmer:
                switch (man.variant)
                {
                    case Variant.none:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.FarmerM;
                        else
                            spriteRenderer.sprite = spriteArchive.FarmerF;
                        return;

                    case Variant._1:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.Farmer1M;
                        else
                            spriteRenderer.sprite = spriteArchive.Farmer1F;
                        return;

                    case Variant._2:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.Farmer2M;
                        else
                            spriteRenderer.sprite = spriteArchive.Farmer2F;
                        return;

                    case Variant._3:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.Farmer3M;
                        else
                            spriteRenderer.sprite = spriteArchive.Farmer3F;
                        return;
                }
                break;
            case Role.soldier:
                switch (man.variant)
                {
                    case Variant.none:
                        if (man.sex == Sex.male)
                            spriteRenderer.sprite = spriteArchive.SoldierM;
                        else                               
                            spriteRenderer.sprite = spriteArchive.SoldierF;
                        return;                              
                                                             
                    case Variant._1:                         
                        if (man.sex == Sex.male)             
                            spriteRenderer.sprite = spriteArchive.Soldier1M;
                        else                             
                            spriteRenderer.sprite = spriteArchive.Soldier1F;
                        return;                                
                                                               
                    case Variant._2:                           
                        if (man.sex == Sex.male)               
                            spriteRenderer.sprite = spriteArchive.Soldier2M;
                        else                                
                            spriteRenderer.sprite = spriteArchive.Soldier2F;
                        return;                               
                                                              
                    case Variant._3:                          
                        if (man.sex == Sex.male)              
                            spriteRenderer.sprite = spriteArchive.Soldier3M;
                        else                                
                            spriteRenderer.sprite = spriteArchive.Soldier3F;
                        return;
                }
                break;
        }		
	}
}
