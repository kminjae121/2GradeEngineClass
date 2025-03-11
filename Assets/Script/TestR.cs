
using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Debug = UnityEngine.Debug;

[Serializable]
public class MyClass
{
    public int age;
    public string name;
    private int number = 0;
    public TestObj testObj;
    public MyClass(int age, string name, int number)
    {
        this.age = age;
        this.name = name;
        this.number = number;
        testObj = new TestObj();
    }

    public void Introduce()
    {
        Debug.Log($"{age}�� �� {name}");
        number++;

    }
}

public class TestObj
{
    public int testAge;
}


public class TestR : MonoBehaviour
{
    
    void Start()
    {
        AssemblyBuilder newAssembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("GGMAssembly"), AssemblyBuilderAccess.Run);

        ModuleBuilder newModule = newAssembly.DefineDynamicModule("GGM");

        TypeBuilder newType = newModule.DefineType("SumTo100");

        //�̸�, ����������, ��ȯ����, �Ű�����
        MethodBuilder newMethod = newType.DefineMethod("Print", MethodAttributes.Public, typeof(int), Type.EmptyTypes);

        ILGenerator generator = newMethod.GetILGenerator();
        generator.Emit(OpCodes.Ldc_I4, 1);  //���ÿ� 32��Ʈ ���� 1�ְ�
                                            //LDC_I4 => Load Constant _integer 4
        for (int i = 2; i <= 100; ++i)
        {
            generator.Emit(OpCodes.Ldc_I4, i);
            generator.Emit(OpCodes.Add); //������ ������ �� ���� ���� ���ѵڿ� ������� �ٽ� push
        }
        generator.Emit(OpCodes.Ret);


        Type t = newType.CreateType();
        //����� �������� �� Ÿ������ �����ϰ� ��� ����    
        object sumTo100 = Activator.CreateInstance(t);
        MethodInfo print = sumTo100.GetType().GetMethod("Print");
        int result = (int)print.Invoke(sumTo100, null);

        Debug.Log(result);
    }
}
