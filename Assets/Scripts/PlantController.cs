﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlantController : MonoBehaviour {
    
    [HideInInspector] public Plant plant;

    public string PlantName { get => plant.name; }
    public string Description { get => plant.description; }
    public Sprite Image { get => Resources.Load<Sprite>(plant.image); }
    public float Width { get => plant.width; }
    public float Height { get => plant.height; }

    private const float GRAVITY_SCALE = 100f;

    private void Start() {
        SetVisual();
        SetPhysicAttributes();
        SetName(name);
    }

    private void Update() { }

    private void SetVisual() {
        GetComponent<RectTransform>().localPosition = Vector2.zero;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
        GetComponent<Image>().sprite = Image;
    }

    private void SetPhysicAttributes() {
        GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<BoxCollider2D>().size = new Vector2(Width, Height);
    }
    
    private void SetName(string name) {
        gameObject.name = name;
    }

    public override string ToString() => plant.ToString();

}
