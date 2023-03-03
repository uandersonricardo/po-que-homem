using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactList
{
    public static List<Contact> contacts = new List<Contact>();

    public static void AddContact(Man man)
    {
        contacts.Add(new Contact(man));
    }

    public static Contact GetContact(string type)
    {
        return contacts.Find(contact => contact.man.type == type);
    }
}
