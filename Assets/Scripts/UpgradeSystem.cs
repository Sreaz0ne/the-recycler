using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    
    public Upgrade[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Upgrade[] GetUpgrades(int numberOfUpgradeNeeded) {

        List<Upgrade> upgradesAvailable = new List<Upgrade>(upgrades);
        List<Upgrade> upgradesFound = new List<Upgrade>();

        for (int i = 0; i < numberOfUpgradeNeeded; i++) {
 
            List<UpgradeProbabilityRange> upr = GetUpgradeProbabilityRangeList(upgradesAvailable);
            int sumProbability = 0;
            
            foreach(Upgrade upgrade in upgradesAvailable)
            {
                sumProbability += upgrade.upgradeProbability;
            }

            int random = Random.Range(1, sumProbability + 1);
            
            foreach(UpgradeProbabilityRange u in upr)
            {
                if ( random >= u.minProbability && random <= u.maxProbability) {
                    upgradesFound.Add(u.upgrade);
                    upgradesAvailable.RemoveAt(upgradesAvailable.IndexOf(u.upgrade));
                    break;
                }
            }
            
        }

        return upgradesFound.ToArray();
    }

    private List<UpgradeProbabilityRange> GetUpgradeProbabilityRangeList(List<Upgrade> upgradesAvailable) {

        List<UpgradeProbabilityRange> upgradesProbabilityRange = new List<UpgradeProbabilityRange>();

        foreach(Upgrade upgrade in upgradesAvailable)
        {
            UpgradeProbabilityRange upr = new UpgradeProbabilityRange();

            if(upgradesProbabilityRange.Count == 0) {
                upr.upgrade = upgrade;
                upr.minProbability = 1;
                upr.maxProbability = upgrade.upgradeProbability; 

                upgradesProbabilityRange.Add(upr);
            } 
            else {
                upr.upgrade = upgrade;
                upr.minProbability = upgradesProbabilityRange[upgradesProbabilityRange.Count - 1].maxProbability + 1;
                upr.maxProbability = upgradesProbabilityRange[upgradesProbabilityRange.Count - 1].maxProbability + upgrade.upgradeProbability;

                upgradesProbabilityRange.Add(upr);
            }
        }

        return upgradesProbabilityRange;
    }

}
