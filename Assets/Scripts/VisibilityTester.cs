using System;
using System.Reflection;
using UnityEngine;

public class VisibilityTester : MonoBehaviour
{
    [Header("GameObject References")]
    [SerializeField] private MonoBehaviour gameManagerScript;
    [SerializeField] private MonoBehaviour uiManagerScript;

    private const BindingFlags LookupFlags = BindingFlags.Public | BindingFlags.NonPublic
        | BindingFlags.Instance | BindingFlags.Static;

    private void Start()
    {
        Debug.Log("--- STARTING ACCESSIBILITY AUDIT ---");

        if (gameManagerScript != null)
        {
            Type gameManagerType = gameManagerScript.GetType();
            TestPropertyAccess(gameManagerType, "Instance");
            TestFieldAccess(gameManagerType, "speed");
            TestPropertyAccess(gameManagerType, "startGame");
        }
        else
        {
            Debug.LogError("[Test Setup] GameManager Script component reference is missing!");
        }

        if (uiManagerScript != null)
        {
            Type uiManagerType = uiManagerScript.GetType();
            TestFieldAccess(uiManagerType, "score");
            TestFieldAccess(uiManagerType, "uiDocument");
        }
        else
        {
            Debug.LogError("[Test Setup] UIManager Script component reference is missing!");
        }

        Debug.Log("--- ACCESSIBILITY AUDIT COMPLETE ---");
    }

    private void TestFieldAccess(Type targetType, string fieldName)
    {
        FieldInfo field = targetType.GetField(fieldName, LookupFlags);
        if (field == null)
        {
            Debug.LogError($"<color=red>[FAIL]</color> Field '{fieldName}' was not found on '{targetType.Name}'.");
            return;
        }

        if (field.IsPublic)
        {
            Debug.Log($"<color=green>[PASS]</color> Field '{fieldName}' on '{targetType.Name}' allows external GET and SET.");
        }
        else
        {
            Debug.LogError($"<color=red>[FAIL]</color> Field '{fieldName}' on '{targetType.Name}' denies external GET and SET.");
        }
    }

    private void TestPropertyAccess(Type targetType, string propertyName)
    {
        PropertyInfo property = targetType.GetProperty(propertyName, LookupFlags);
        if (property == null)
        {
            Debug.LogError($"<color=red>[FAIL]</color> Property '{propertyName}' was not found on '{targetType.Name}'.");
            return;
        }

        if (property.GetGetMethod() != null)
        {
            Debug.Log($"<color=green>[PASS]</color> Property '{propertyName}' on '{targetType.Name}' allows external GET.");
        }
        else
        {
            Debug.LogError($"<color=red>[FAIL]</color> Property '{propertyName}' on '{targetType.Name}' denies external GET.");
        }

        if (property.GetSetMethod() != null)
        {
            Debug.Log($"<color=green>[PASS]</color> Property '{propertyName}' on '{targetType.Name}' allows external SET.");
        }
        else
        {
            Debug.LogError($"<color=red>[FAIL]</color> Property '{propertyName}' on '{targetType.Name}' denies external SET.");
        }
    }
}
