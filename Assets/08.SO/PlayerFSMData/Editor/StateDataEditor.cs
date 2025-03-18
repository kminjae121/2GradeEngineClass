using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(StateDataSO))]
public class StateDataEditor : UnityEditor.Editor
{
    [SerializeField] private VisualTreeAsset inspectorUI = default;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();
        inspectorUI.CloneTree(root); //ui�� �����ؼ� root�� �ڽ����� �־��ֶ�.

        DropdownField dropdown = root.Q<DropdownField>("ClassDropDownField");

        CreateDropdownChoices(dropdown);

        return root;
    }

    private void CreateDropdownChoices(DropdownField dropdown)
    {
        dropdown.choices.Clear();
        //EntityState ��� Ŭ������ �����ִ� ������� �����´�.
        Assembly fsmAssembly = Assembly.GetAssembly(typeof(EntityState));

        List<string> typeList = fsmAssembly.GetTypes()
            .Where(type => type.IsAbstract == false && type.IsSubclassOf(typeof(EntityState)))
            .Select(type => type.FullName)
            .ToList();

        dropdown.choices.AddRange(typeList);
    }
}
