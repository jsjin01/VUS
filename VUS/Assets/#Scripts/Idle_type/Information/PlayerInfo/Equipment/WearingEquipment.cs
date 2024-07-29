using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WearingEquipment : MonoBehaviour
{
    EquipmentData equipmentData;            //������ ����� ������
    [SerializeField] EQUIPMENTTYPE equipType;//�ش� ĭ�� ���� Ÿ��
    [SerializeField] Sprite[] sprite;       //������ �̹��� 
    [SerializeField] Image img;             //�ش� ĭ �̹��� ��ȯ 
    [SerializeField] string path;           //�ش� ĭ�� ��� ����
    [SerializeField] GameObject wearingEquipInfo;
    [SerializeField] GameObject Blocker;

    [Header("Cloth,Ammor,Pant ����")]
    [SerializeField] Image centerImg; //��� �̹���
    [SerializeField] Image rightImg; //������ �̹���
    [SerializeField] Image leftImg;   //���� �̹���
    //������ �̹���
    [SerializeField] Sprite[] centerSprite;
    [SerializeField] Sprite[] rightSprite;
    [SerializeField] Sprite[] leftSprite;
    private void Start()
    {
        DataLoad();
    }

    void DataLoad() //������ �ε� ����
    {
        string filePath = Path.Combine(Application.dataPath, path);

        if(File.Exists(filePath))
        {
            // JSON ���� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON �����͸� EquipmentData ��ü�� ��ȯ 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);

            //�̹��� ����
            if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//�̹����� 3���� ���ľ��ϴ� ���
            {
                centerImg.sprite = centerSprite[equipmentData.id];
                rightImg.sprite = rightSprite[equipmentData.id];
                leftImg.sprite = leftSprite[equipmentData.id];

                SizeControl(ref centerImg);
                SizeControl(ref rightImg);
                SizeControl(ref leftImg);
            }
            else if(equipType == EQUIPMENTTYPE.PANT)//�̹����� 2���� ���ľ��ϴ� ��� 
            {
                rightImg.sprite = rightSprite[equipmentData.id];
                leftImg.sprite = leftSprite[equipmentData.id];

                SizeControl(ref rightImg);
                SizeControl(ref leftImg);
            }
            else//������ ���
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

    public void ShowButton()//�����͸� �����ִ� ��ư 
    {
        Blocker.GetComponent<Canvas>().sortingOrder += 1;
        wearingEquipInfo.SetActive(true);
        wearingEquipInfo.transform.GetChild(2).GetComponent<Text>().text = equipmentData.name;
        wearingEquipInfo.transform.GetChild(5).GetComponentInChildren<Text>().text =
            $"{((equipmentData.attackPower != 0) ? "���ݷ� : + " + equipmentData.attackPower + "\n" : null)}" +
            $"{((equipmentData.magicPower != 0) ? "�ֹ��� : + " + equipmentData.magicPower + "\n" : null)}" +
            $"{((equipmentData.speed != 0) ? "�̵� �ӵ� : + " + equipmentData.speed + "\n" : null)}" +
            $"{((equipmentData.maxHp != 0) ? "��ü��ȭ : + " + equipmentData.maxHp / 10 + "\n" : null)}" +
            $"{((equipmentData.cri != 0) ? "ġ��Ÿ : + " + equipmentData.cri + "\n" : null)}" +
            $"{((equipmentData.criDmg != 0) ? "ġ��Ÿ ������ : + " + equipmentData.criDmg + "\n" : null)}";
        SynergySort();
    }

    void SynergySort() //�ó��� �����ϴ� �Լ� 
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

    void SizeControl(ref Image img) //�� �̹��� ũ�⿡ ���� �ٸ��� ���� 
    {
        if(img.sprite == null)
        {
            return;
        }

        Texture2D spriteImg = img.sprite.texture; //�̹��� ũ�� �����ϱ� 
        float spriteImgWidth = spriteImg.width;
        float spriteImgHeight = spriteImg.height;

        img.GetComponent<RectTransform>().sizeDelta = new Vector2 (spriteImgWidth, spriteImgHeight);
    }
}
