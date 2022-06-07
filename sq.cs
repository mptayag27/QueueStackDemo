using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sq : MonoBehaviour
{
    GameObject pink;
    GameObject gree;
    GameObject blue;
    bool isqueue;
    bool isstack;
    Stack<int> st;
    Queue<int> qu;
    float time = 0.0f;
    float interval = 0.5f;
    bool popper;
    // Start is called before the first frame update
    void Start()
    {
        pink = GameObject.Find("pink");
        gree = GameObject.Find("gree");
        blue = GameObject.Find("blue");
        isqueue = false;
        isstack = false;
        st = new Stack<int>();
        qu = new Queue<int>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.S))
        {
            isstack = true;
            print("s");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            isqueue = true;
        }
        if(isstack)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                st.Push(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                st.Push(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                st.Push(3);
            }
        }
        else if (isqueue)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                qu.Enqueue(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                qu.Enqueue(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                qu.Enqueue(3);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            popper = true;
        }
        if (time > interval)
        {
            if (popper)
            {
                if (isstack)
                {
                    float vx = GameObject.Find("shell").transform.position.x;
                    int k;
                    if (st.Count > 0)
                    {
                        k = st.Pop();
                        if (k == 1)
                        {
                            GameObject obj = (GameObject)Instantiate(blue, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        else if (k == 2)
                        {
                            GameObject obj = (GameObject)Instantiate(gree, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        else if (k == 3)
                        {
                            GameObject obj = (GameObject)Instantiate(pink, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        vx += 2;
                        time = 0;
                    }
                    
                    if(st.Count==0)
                    {
                        isstack = false;
                        popper = false;
                    }
                }
                else if (isqueue)
                {
                    float vx = GameObject.Find("shell").transform.position.x;
                    int k;
                    if (qu.Count > 0)
                    {
                        k = qu.Dequeue();
                        if (k == 1)
                        {
                            GameObject obj = (GameObject)Instantiate(blue, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        else if (k == 2)
                        {
                            GameObject obj = (GameObject)Instantiate(gree, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        else if (k == 3)
                        {
                            GameObject obj = (GameObject)Instantiate(pink, new Vector2(vx, GameObject.Find("shell").transform.position.y), Quaternion.identity);
                        }
                        vx += 2;
                        time = 0;
                    }
                    
                    if(qu.Count==0)
                    {
                        isqueue = false;
                        popper = false;
                    }
                }
            }
        }
    }
}
