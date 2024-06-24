
int[] unsortedArray = [5, 3, 8, 4, 2, 7, 9, 1, 6];
int[] sortedArray = TreeSort(unsortedArray);
Console.WriteLine("原数组: " + string.Join(", ", unsortedArray));
Console.WriteLine("排序后: " + string.Join(", ", sortedArray));

static int[] TreeSort(int[] array)
{
    // 默认根节点为空
    TreeNode? root = null;
    // 构建二叉搜索树
    foreach (int value in array)
    {
        root = Insert(root, value);
    }

    // 中序遍历二叉搜索树并获取排序后的元素
    List<int> sortedList = [];
    InOrderTraversal(root, sortedList);
    return sortedList.ToArray();
}


// 从节点node开始，插入值value
static TreeNode Insert(TreeNode? node, int value)
{
    // 节点为空时，插入新节点
    if (node == null)
        return new TreeNode(value);

    // 小于当前节点值时，插入左子树
    if (value < node.Value)
    {
        node.Left = Insert(node.Left, value);
    }
    // 大于等于当前节点值时，插入右子树
    else
    {
        node.Right = Insert(node.Right, value);
    }
    return node;
}

// 搜索node节点下最小值
static void InOrderTraversal(TreeNode? node, List<int> result)
{
    if (node == null)
        return;

    // 遍历搜索左子树
    InOrderTraversal(node.Left, result);
    result.Add(node.Value);
    // 遍历搜索右子树
    InOrderTraversal(node.Right, result);
}

// 定义树型结构
public class TreeNode(int value)
{
    public int Value = value;
    // 左子树
    public TreeNode? Left = null;
    // 右子树
    public TreeNode? Right = null;
}