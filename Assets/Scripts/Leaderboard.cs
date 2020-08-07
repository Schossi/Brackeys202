using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public int Stage;
    public TMPro.TextMeshProUGUI TextMesh;

    // Start is called before the first frame update
    void Start()
    {
        GlobalstatsIO gs = new GlobalstatsIO();
        string gtd = "Stage" + Stage;
        int limit = 10;
        var lb = gs.getLeaderboard(gtd, limit);

        StringBuilder sb = new StringBuilder();
        foreach (var item in lb.data)
        {
            sb.AppendLine($@"<align=left>{item.rank}<line-height=0>
<align=center>{item.name}<line-height=0>
<align=right>{item.value}<line-height=1em>");
        }

        TextMesh.text = sb.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
