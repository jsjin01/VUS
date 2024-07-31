using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class MeasureData
{
    public int id;
    public int width;
    public int height;

    public int armWidth;
    public int armHeight;
}

public class WearingEquipment : MonoBehaviour
{
    EquipmentData equipmentData;            //착용한 장비의 데이터
    [SerializeField] EQUIPMENTTYPE equipType;//해당 칸의 무기 타입
    [SerializeField] Sprite[] sprite;       //장비들의 이미지 
    [SerializeField] Image img;             //해당 칸 이미지 변환 
    [SerializeField] string path;           //해당 칸의 경로 설정
    [SerializeField] GameObject wearingEquipInfo;
    [SerializeField] GameObject Blocker;

    [Header("Cloth,Ammor,Pant 전용")]
    [SerializeField] Image centerImg; //가운데 이미지
    [SerializeField] Image rightImg; //오른쪽 이미지
    [SerializeField] Image leftImg;   //왼쪽 이미지
    //장비들의 이미지
    [SerializeField] Sprite[] centerSprite;
    [SerializeField] Sprite[] rightSprite;
    [SerializeField] Sprite[] leftSprite;

    List<MeasureData> MeasureDataList;

    private void Start()
    {
        MeasureDataByType(equipType);
        DataLoad();
    }

    void DataLoad() //데이터 로드 과정
    {
        string filePath = Path.Combine(Application.dataPath, path);

        if(File.Exists(filePath))
        {
            // JSON 파일 읽기
            string jsonData = File.ReadAllText(filePath);

            // JSON 데이터를 EquipmentData 객체로 변환 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);

            //이미지 적용
            if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//이미지를 3개를 합쳐야하는 경우
            {
                centerImg.sprite = centerSprite[equipmentData.id];
                rightImg.sprite = rightSprite[equipmentData.id];
                leftImg.sprite = leftSprite[equipmentData.id];

                //SizeControl(ref centerImg);
                //SizeControl(ref rightImg);
                //SizeControl(ref leftImg);

                MeasureBodySizeControl(ref centerImg, equipmentData.id);
                MeasureArmSizeControl(ref rightImg, equipmentData.id);
                MeasureArmSizeControl(ref leftImg, equipmentData.id);

            }
            else if(equipType == EQUIPMENTTYPE.PANT)//이미지를 2개를 합쳐야하는 경우 
            {
                rightImg.sprite = rightSprite[equipmentData.id];
                leftImg.sprite = leftSprite[equipmentData.id];

                SizeControl(ref rightImg);
                SizeControl(ref leftImg);
            }
            else//나머지 경우
            {
                img.sprite = sprite[equipmentData.id];

                SizeControl(ref img);
            }
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }
    }

    public void ShowButton()//데이터를 보여주는 버튼 
    {
        Blocker.GetComponent<Canvas>().sortingOrder += 1;
        wearingEquipInfo.SetActive(true);
        wearingEquipInfo.transform.GetChild(2).GetComponent<Text>().text = equipmentData.name;
        wearingEquipInfo.transform.GetChild(5).GetComponentInChildren<Text>().text =
            $"{((equipmentData.attackPower != 0) ? "공격력 : + " + equipmentData.attackPower + "\n" : null)}" +
            $"{((equipmentData.magicPower != 0) ? "주문력 : + " + equipmentData.magicPower + "\n" : null)}" +
            $"{((equipmentData.speed != 0) ? "이동 속도 : + " + equipmentData.speed + "\n" : null)}" +
            $"{((equipmentData.maxHp != 0) ? "육체강화 : + " + equipmentData.maxHp / 10 + "\n" : null)}" +
            $"{((equipmentData.cri != 0) ? "치명타 : + " + equipmentData.cri + "\n" : null)}" +
            $"{((equipmentData.criDmg != 0) ? "치명타 데미지 : + " + equipmentData.criDmg + "\n" : null)}";
        SynergySort();
    }

    void SynergySort() //시너지 정렬하는 함수 
    {
        switch(equipmentData.synergy)
        {
            case EQUIPMENTSYNERGY.NONE:
                for(int i = 0; i < 6; i++)
                {
                    wearingEquipInfo.transform.GetChild(6).GetChild(i).GetComponent<Text>().text = null;
                }
                break;
            default:
                break;
        }
    }

    void SizeControl(ref Image img) //들어간 이미지 크기에 따라 다르게 설정 
    {
        if(img.sprite == null)
        {
            return;
        }

        Texture2D spriteImg = img.sprite.texture; //이미지 크기 추출하기 
        float spriteImgWidth = spriteImg.width;
        float spriteImgHeight = spriteImg.height;

        img.GetComponent<RectTransform>().sizeDelta = new Vector2(spriteImgWidth, spriteImgHeight);
    }

    void MeasureDataByType(EQUIPMENTTYPE type)//타입(Armor, Cloth, Pants)에 따른 데이터 값 로딩
    {
        string jsonData = "";

        switch(type)
        {
            case EQUIPMENTTYPE.ARMOR:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/ArmorMeasure.json");
                break;
            case EQUIPMENTTYPE.CLOTH:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/ClothMeasure.json");
                break;
            case EQUIPMENTTYPE.PANT:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/PantsMeasure.json");
                break;
            default:
                return;
        }

        MeasureData[] dataArray = JsonHelper.FromJson<MeasureData>(jsonData);
        MeasureDataList = new List<MeasureData>(dataArray);
    }

    void MeasureBodySizeControl(ref Image img, int index) //측정데이터에 따른 이미지 크기 설정(Body) 
    {
        MeasureData data = GetMeasureDataById(index);
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(data.width * 5, data.height * 5);
    }

    void MeasureArmSizeControl(ref Image img, int index) //측정데이터에 따른 이미지 크기 설정(Arm && Pants) 
    {
        MeasureData data = GetMeasureDataById(index);
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(data.armWidth * 5, data.armHeight * 5);
    }

    MeasureData GetMeasureDataById(int id) // 특정 ID에 해당하는 데이터를 검색
    {
        return MeasureDataList.Find(data => data.id == id);
    }
    public static class JsonHelper //Json 배열을 객체 배열로 변환하는 클래스 => 쉽게 말해서 json에 배열 사용하기 위해서 사용
    {
        public static T[] FromJson<T>(string json)
        {
            string newJson = "{\"array\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }

}
