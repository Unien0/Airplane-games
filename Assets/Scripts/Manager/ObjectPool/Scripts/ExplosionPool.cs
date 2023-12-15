using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 继承了BasePool的一个实现功能的子对象池
/// 继承时将泛型替换为某一特定类型，即为该类型对象的对象池，这里装的是挂载在爆炸特效上的NewExplosion类
/// </summary>
public class ExplosionPool : BasePool<NewExplosion>
{
    //如同先前提到的，需要在awake函数中初始化建立pool
    void Awake()
    {
        Initialized();
    }

    //如果不需要对父类中的方法进行修改，则不需要重写
    //反之，需要在方法体中加入新的代码或者修改老代码，需要重写，使用override关键字，并保持和父类方法一样的权限
    //因为泛型的引入，基类的所有T型obj不需要重写就会自动转换为NewExplosion型



    //此方法是专门用于实现移动从池中抽出的对象的坐标的
    //通过基类设定的公开方法Get（）得到抽出的对象，并将该对象的坐标改变成需要的坐标
    //需要的坐标作为形参被引入，保证实现稳定的一一对应关系（这也是不使用广播或者findobject等方法的原因）
    public void GetExplosion(Vector3 pos)
    {
        var temp = Get();
        temp.transform.position = pos;
    }

    //此方法用于将对象释放回池
    //实际上这一步通过直接调用基类的 Release()方法实现效果是一模一样的，不过因为在对应的子类定义名字可读性强的方法便于后期阅读的想法，作者强迫症犯了所以套娃
    //如果你实在觉得套娃是不好的，那我建议你不要删除套娃，而是把Release()的权限改为protected，这样是不是就舒服多了
    public void ReleaseExplosion(NewExplosion obj)
    {
        Release(obj);
    }
}
