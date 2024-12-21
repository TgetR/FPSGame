using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HistorySaver : MonoBehaviour
{
[SerializeField] GameObject LG1;
[SerializeField] GameObject LG2;
[SerializeField] GameObject LG3;
[SerializeField] GameObject LG4;
[SerializeField] GameObject LG5;
int time1;
int damage1;
int generations1;
int kills1;

int time2;
int damage2;
int generations2;
int kills2;

int time3;
int damage3;
int generations3;
int kills3;

int time4;
int damage4;
int generations4;
int kills4;

int time5;
int damage5;
int generations5;
int kills5;
void Start()
{
 time1 = PlayerPrefs.GetInt("Time");
 damage1 = PlayerPrefs.GetInt("Damage");
 generations1 = PlayerPrefs.GetInt("Generations");
 kills1 = PlayerPrefs.GetInt("EnemyKilled");
 /****************************************************************************************************************************************************************/
 if(time1 != time2)
 {
 LG1.transform.GetChild(0).GetComponent<TMP_Text>().text = "Time: " + time1 + "s";
 LG1.transform.GetChild(1).GetComponent<TMP_Text>().text = "Damage: " + damage1;
 LG1.transform.GetChild(2).GetComponent<TMP_Text>().text = "Kils: " + kills1;
 LG1.transform.GetChild(3).GetComponent<TMP_Text>().text = "Generations: " + generations1;

 time2 = time1;
 damage2 = damage1;
 generations2 = generations1;
 kills2 = kills1;
 }

 if(time2 != time3)
 {
 LG2.transform.GetChild(0).GetComponent<TMP_Text>().text = "Time: " + time2 + "s";
 LG2.transform.GetChild(1).GetComponent<TMP_Text>().text = "Damage: " + damage2;
 LG2.transform.GetChild(2).GetComponent<TMP_Text>().text = "Kils: " + kills2;
 LG2.transform.GetChild(3).GetComponent<TMP_Text>().text = "Generations: " + generations2;

 time3 = time2;
 damage3 = damage2;
 generations3 = generations2;
 kills3 = kills2;
 }

if(time3 != time4)
 {
 LG3.transform.GetChild(0).GetComponent<TMP_Text>().text = "Time: " + time3 + "s";
 LG3.transform.GetChild(1).GetComponent<TMP_Text>().text = "Damage: " + damage3;
 LG3.transform.GetChild(2).GetComponent<TMP_Text>().text = "Kils: " + kills3;
 LG3.transform.GetChild(3).GetComponent<TMP_Text>().text = "Generations: " + generations3;

 time4 = time3;
 damage4 = damage3;
 generations4 = generations3;
 kills4 = kills3;
 }
if(time4 != time5)
 {
 LG4.transform.GetChild(0).GetComponent<TMP_Text>().text = "Time: " + time4 + "s";
 LG4.transform.GetChild(1).GetComponent<TMP_Text>().text = "Damage: " + damage4;
 LG4.transform.GetChild(2).GetComponent<TMP_Text>().text = "Kils: " + kills4;
 LG4.transform.GetChild(3).GetComponent<TMP_Text>().text = "Generations: " + generations4;

 time4 = time5;
 damage4 = damage5;
 generations4 = generations5;
 kills4 = kills5;
 }
 else
 {
 LG5.transform.GetChild(0).GetComponent<TMP_Text>().text = "Time: " + time5 + "s";
 LG5.transform.GetChild(1).GetComponent<TMP_Text>().text = "Damage: " + damage5;
 LG5.transform.GetChild(2).GetComponent<TMP_Text>().text = "Kils: " + kills5;
 LG5.transform.GetChild(3).GetComponent<TMP_Text>().text = "Generations: " + generations5;
 }
}
}
