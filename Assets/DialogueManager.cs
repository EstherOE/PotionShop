using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
	[SerializeField] int index=0;
    
	[SerializeField] TextMeshProUGUI dialogueText;
	[SerializeField] TextMeshProUGUI nameText;
	[SerializeField] TextMeshProUGUI recipeText;
	
	public string [] Lines ={
		"Hello, welcome to my coffee shop",
		"what would you like today?",
		"We have speecial drinks for you"
	};
	
	private string [] names={"Luna", "Luna", "Luna"};
	private bool istyping= false;
	
	private string basedrink="";
	private string incredient_one="";
	private string incredient_two="";
	// Start is called before the first frame update
    void Start()
	{
		ShowLine();
        
	    
	}
    
	void ShowLine()
	{
		nameText.text= names[index];
		StartCoroutine(TypeLine(Lines[index]));
	}


	IEnumerator TypeLine(string line)
	{
		istyping= true;
		dialogueText.text= "";
		foreach(char c in line)
		{
			dialogueText.text +=c;
			yield  return new WaitForSeconds(0.05f);
		}
		istyping= false;
	}
	
	
	public void Nextline()
	{
		if(istyping) {
			StopAllCoroutines();
			dialogueText.text= Lines[index];
			istyping= false;
			return;
			
		}
		index++;
		if(index <Lines.Length)
		{
			ShowLine();
		}
	}

	void UpdateText(){
		recipeText.text= $"Selected: {basedrink}, {incredient_one}, {incredient_two}";
	}
	public void SelectCoffee()
	{
		basedrink= "Coffee";
		UpdateText();
	}
	
	public void SelectGinger()
	{
		if(incredient_one=="")
			incredient_one= "Ginger";
		else 
			incredient_two= "Ginger";
		UpdateText();
	}
	
	
	public void SelectCinnamon()
	{
		if(incredient_one=="")
			incredient_one= "Cinnamon";
		else 
			incredient_two= "Cinnamon";
		UpdateText();
	}
	
	public void SelectBrew()
	{
		string result= basedrink + ","+ incredient_one + ","+ incredient_two;
		
		if(result=="Coffee,Ginger,Cinnamon")
		{
			Debug.Log("Correct Drink !!");
		}	
		else 
		{
			Debug.Log("Wrong Drink !!");
		}	
			
		ResetDrink();
	}
	
	void ResetDrink()
	{
		incredient_one="";
		incredient_two="";
		basedrink="";
		UpdateText();
	}
	
}
