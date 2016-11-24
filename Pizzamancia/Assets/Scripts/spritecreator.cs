using UnityEngine;
using System.Collections;
 [ExecuteInEditMode]

[System.Serializable]
public struct BlocoInstanciado {
    public GameObject prefab;
    public Color cor;
    public int pixellock;

};

public class spritecreator : MonoBehaviour {

    public BlocoInstanciado[] blocos;
    public int pixellocky;
    //public bool execute=false;
	//public bool destruir=false;
    public Texture2D sourceTex;
    //public Texture sourceraw;
    float spritesize=0.35f;

    IEnumerator Start()
    //void Start()
	{
		// Implementar a geração direta do mapa no Start sem botão dentro do editor
		yield return StartCoroutine ("GenerateSprite");
	}

    public IEnumerator GenerateSprite()
    {

        for (int indiceBloco = 0; indiceBloco < blocos.Length; indiceBloco++)
        {

            blocos[indiceBloco].cor = sourceTex.GetPixel(blocos[indiceBloco].pixellock, pixellocky);

        }

    
        // Estrutura de repetição para ler cada pixel da imagem em linha (X)
        for (int x = 0; x < sourceTex.width; x++)
        {
            // Estrutra de repetição para lermos a colunas (Y) da imagem para um determinada linha (X)
            for (int y = 0; y < sourceTex.height; y++)
            {
                Color pixel = sourceTex.GetPixel(x, y);

                for (int indiceBloco = 0; indiceBloco < blocos.Length; indiceBloco++)

                {

                   
                    //if (pixel.Equals(blocos[indiceBloco].cor))
                    if (pixel.r == blocos[indiceBloco].cor.r && pixel.g == blocos[indiceBloco].cor.g && pixel.b == blocos[indiceBloco].cor.b)
                    {
                        // Instanciar um Prefab
                        GameObject clone = GameObject.Instantiate(blocos[indiceBloco].prefab);
                        clone.transform.parent = transform;
                        clone.transform.position = new Vector3(transform.position.x + x * spritesize, transform.position.y + y * spritesize, 0);
                    }
                    else
                    {
                    }
                }
            }
        }

        yield return null;

    }

    public GameObject AddSprite(Sprite d)
    {
  		GameObject sprGameObj = new GameObject();
		sprGameObj.name = "bloco";
        sprGameObj.AddComponent<SpriteRenderer>();
        SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
        sprRenderer.sprite = d;
        return sprGameObj;
    }
}
