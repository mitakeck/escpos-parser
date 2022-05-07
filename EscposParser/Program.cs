// See https://aka.ms/new-console-template for more information
using System.Text;

string input = Console.In.ReadToEnd();

CommandNode root = new CommandNode
{
    Nodes = new CommandNode[] {
        new CommandNode {
            Code = '\x09',
            Description = "HT 水平タブ",
        },
        new CommandNode
        {
            Code = '\x0A',
            Description = "LF 印字改行",
        },
        new CommandNode
        {
            Code = '\x0C',
            Description = "FF (ページモード) ページモードの印字と復帰",
        },
        new CommandNode
        {
            Code = '\x0D',
            Description = "CR 印字復帰",
        },
        new CommandNode
        {
            Code = '\x10',
            Nodes = new CommandNode[]
            {
                 new CommandNode
                 {
                    Code = '\x04',
                    Description = "DLE EOT ステータスのリアルタイム送信",
                 },
                 new CommandNode
                 {
                    Code = '\x05',
                    Description = "DLE ENQ プリンターへのリアルタイム要求",
                    Skip = 1,
                 },
                 new CommandNode
                 {
                    Code = '\x14',
                    Nodes= new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x01',
                            Description = "DLE DC4 (fn=1) 指定パルスのリアルタイム出力",
                            Skip = 2,
                        },
                        new CommandNode
                        {
                            Code = '\x02',
                            Description = "DLE DC4 (fn=2) 電源オフ処理の実行",
                            Skip = 2,
                        },
                        new CommandNode
                        {
                            Code = '\x03',
                            Description = "DLE DC4 (fn=3) ブザーのリアルタイム鳴動",
                            Skip = 5,
                        },
                        new CommandNode
                        {
                            Code = '\x07',
                            Description = "DLE DC4 (fn=7) 特定ステータスのリアルタイム送信",
                            Skip = 1,
                        },
                        new CommandNode
                        {
                            Code = '\x08',
                            Description = "DLE DC4 (fn=8) バッファークリア",
                            Skip = 8,
                        },
                    }
                 },
            },
        },
        new CommandNode {
            Code = '\x18',
            Description = "CAN ページモードにおける印字データのキャンセル",
        },
        new CommandNode {
            Code = '\x1b',
            Nodes = new CommandNode[]
            {
                new CommandNode
                {
                    Code = '\x0c',
                    Description = "ESC FF ページモードのデータ印字",
                },
                new CommandNode
                {
                    Code = '\x20',
                    Description = "ESC SP 文字の右スペース量の設定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x21',
                    Description = "ESC ! 印字モードの一括指定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x24',
                    Description = "ESC $ 絶対位置の指定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x25',
                    Description = "ESC % ダウンロード文字セットの指定・解除",
                    Skip = 1,
                },
                //new CommandNode
                //{
                //    Code = '\x26',
                //    Description = "ESC & ダウンロード文字の定義",
                //    Skip = TODO,
                //},
                new CommandNode
                {
                    Code = '\x28',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x41',
                            Nodes = new CommandNode[]
                            {
                                new CommandNode
                                {
                                    Code = '\x03',
                                    Description = "ESC ( A   <機能97> ブザーの鳴動",
                                    Skip = 4,
                                },
                                new CommandNode
                                {
                                    Code = '\x04',
                                    Description = "ESC ( A   <機能48> ブザーの鳴動",
                                    Skip = 5,
                                },
                            },
                        },
                        new CommandNode
                        {
                            Code = '\x59',
                            Description = "ESC ( Y まとめ印刷の指定",
                            Skip = 4,
                        },
                    },
                },
                //new CommandNode
                //{
                //    Code = '\x2a',
                //    Description = "ESC * ビットイメージモードの指定",
                //    Skip = TODO,
                //},
                new CommandNode
                {
                    Code = '\x2d',
                    Description = "ESC - アンダーラインの指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x32',
                    Description = "ESC 2 初期改行量の設定",
                },
                new CommandNode
                {
                    Code = '\x33',
                    Description = "ESC 3 改行量の設定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x3c',
                    Description = "ESC < リターンホーム",
                },
                new CommandNode
                {
                    Code = '\x3d',
                    Description = "ESC = 周辺機器の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x3f',
                    Description = "ESC ? ダウンロード文字の抹消",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x40',
                    Description = "ESC @ プリンターの初期化",
                },
                //new CommandNode
                //{
                //    Code = '\x44',
                //    Description = "ESC D 水平タブ位置の設定",
                //    Skip = TODO,
                //},
                new CommandNode
                {
                    Code = '\x45',
                    Description = "ESC E 強調印字の指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x47',
                    Description = "ESC G 二重印字の指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x4a',
                    Description = "ESC J 印字および紙送り",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x4b',
                    Description = "ESC K 印字および逆方向紙送り",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x4c',
                    Description = "ESC L ページモードの選択",
                },
                new CommandNode
                {
                    Code = '\x4d',
                    Description = "ESC M 文字フォントの選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x52',
                    Description = "ESC R 国際文字の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x53',
                    Description = "ESC S スタンダードモードの選択",
                },
                new CommandNode
                {
                    Code = '\x54',
                    Description = "ESC T ページモードにおける文字の印字方向の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x55',
                    Description = "ESC U 単方向印字の指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x56',
                    Description = "ESC V 文字の90度右回転の指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x57',
                    Description = "ESC W ページモードにおける印字領域の設定",
                    Skip = 8,
                },
                new CommandNode
                {
                    Code = '\x5c',
                    Description = "ESC \\ 相対位置の指定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x61',
                    Description = "ESC a 位置揃え",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x63',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x33',
                            Description = "ESC c 3 紙なし信号出力に有効な紙なし検出器の選択",
                            Skip = 1,
                        },
                        new CommandNode
                        {
                            Code = '\x34',
                            Description = "ESC c 4 印字停止に有効な紙なし検出器の選択",
                            Skip = 1,
                        },
                        new CommandNode
                        {
                            Code = '\x35',
                            Description = "ESC c 5 パネルスイッチの有効・無効",
                            Skip = 1,
                        },
                    },
                },
                new CommandNode
                {
                    Code = '\x64',
                    Description = "ESC d 印字およびn行の紙送り",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x65',
                    Description = "ESC e 印字およびn行の逆方向紙送り",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x69',
                    Description = "ESC i   [非推奨コマンド] パーシャルカット (1点を残す)",
                },
                new CommandNode
                {
                    Code = '\x6d',
                    Description = "ESC m   [非推奨コマンド] パーシャルカット (3点を残す)",
                },
                new CommandNode
                {
                    Code = '\x70',
                    Description = "ESC p 指定パルスの発生",
                    Skip = 3,
                },
                new CommandNode
                {
                    Code = '\x72',
                    Description = "ESC r 印字色の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x74',
                    Description = "ESC t 文字コードテーブルの選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x75',
                    Description = "ESC u   [非推奨コマンド] 周辺機器ステータスの送信",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x76',
                    Description = "ESC v   [非推奨コマンド] 用紙検出器ステータスの送信",
                },
                new CommandNode
                {
                    Code = '\x7b',
                    Description = "ESC { 倒立印字の指定・解除",
                    Skip = 1,
                },
            },
        },
        new CommandNode
        {
            Code = '\x1c',
            Nodes = new CommandNode[]
            {
                new CommandNode
                {
                    Code = '\x21',
                    Description = "FS ! 漢字の印字モードの一括指定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x26',
                    Description = "FS & 漢字モードの指定",
                },
                new CommandNode
                {
                    Code = '\x28',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x41',
                            Description = "FS ( A   <機能48> 漢字フォントの選択",
                            Skip = 4,
                        },
                        new CommandNode
                        {
                            Code = '\x43',
                            Nodes = new CommandNode[]
                            {
                                new CommandNode
                                {
                                    Code = '\x02',
                                    Description = "FS ( C   <機能48> 文字のエンコード種類の選択",
                                    Skip = 3,
                                },
                                new CommandNode
                                {
                                    Code = '\x03',
                                    Description = "FS ( C   <機能60> フォント優先順位設定",
                                    Skip = 4,
                                },
                            },
                        },
                        new CommandNode
                        {
                            Code = '\x45',
                            Description = "FS ( E TODO",
                            Nodes = new CommandNode[]
                            {
                                //new CommandNode
                                //{
                                //    Code = '\x06',
                                //    Description = "FS ( E   <機能60> トップロゴ/ボトムロゴ印字の設定値の抹消",
                                //    Skip = 7,
                                //},
                                //new CommandNode
                                //{
                                //    Code = '\x03',
                                //    Description = "FS ( E   <機能61> トップロゴ/ボトムロゴ印字の設定値の送信",
                                //    Skip = 4,
                                //},
                                //new CommandNode
                                //{
                                //    Code = '\x03',
                                //    Description = "FS ( E   <機能61> トップロゴ/ボトムロゴ印字の設定値の送信",
                                //    Skip = 4,
                                //},
                            },
                        },
                        new CommandNode
                        {
                            Code = '\x4c',
                            Description = "FS ( L TODO",
                        },
                        new CommandNode
                        {
                            Code = '\x65',
                            Description = "FS ( e 拡張機能に関する自動ステータス送信の有効・無効",
                            Skip = 4,
                        },
                    },
                },
                new CommandNode
                {
                    Code = '\x2d',
                    Description = "FS - 漢字アンダーラインの指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x2e',
                    Description = "FS . 漢字モードの解除",
                },
                //new CommandNode
                //{
                //    Code = '\x32',
                //    Description = "FS 2 外字の定義",
                //    Skip = TODO,
                //},
                new CommandNode
                {
                    Code = '\x3f',
                    Description = "FS ? 外字の抹消",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x43',
                    Description = "FS C 漢字コード体系の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x53',
                    Description = "FS S 漢字のスペース量の設定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x57',
                    Description = "FS W 漢字の4倍角文字の指定・解除",
                    Skip = 1,
                },
                //new CommandNode
                //{
                //    Code = '\x67',
                //    Description = "FS g 1   [非推奨コマンド]  ユーザーNVメモリーへのデータ書き込み",
                //    Skip = TODO,
                //},
                new CommandNode
                {
                    Code = '\x70',
                    Description = "FS p   [非推奨コマンド] NVビットイメージの印字",
                    Skip = 2,
                },
                //new CommandNode
                //{
                //    Code = '\x71',
                //    Description = "FS q   [非推奨コマンド] NVビットイメージの定義",
                //    Skip = TODO,
                //},
            },
        },
        new CommandNode {
            Code = '\x1d',
            Nodes = new CommandNode[]
            {
                new CommandNode
                {
                    Code = '\x21',
                    Description = "GS ! 文字サイズの指定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x24',
                    Description = "GS $ ページモードにおける文字縦方向絶対位置の指定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x28',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x41',
                            Description = "GS ( A テスト印字の実行",
                            Skip = 4,
                        },
                        new CommandNode
                        {
                            Code = '\x43',
                            Nodes = new CommandNode[]
                            {
                                new CommandNode
                                {
                                    Code = '\x05',
                                    Description = "GS ( C   <機能0> 指定レコードの消去",
                                    Skip = 6,
                                },
                                // TODO
                            },
                        },
                        // TODO GS ( D 
                        // TODO GS ( E
                        // TODO GS ( H
                        // TODO GS ( K
                        // TODO GS ( L   /   GS 8 L
                        // TODO GS ( M
                        // TODO GS ( N
                        // TODO GS ( P
                        // TODO GS ( Q
                        // TODO GS ( k
                    },
                },
                // TODO GS *   [非推奨コマンド]
                // TODO GS /   [非推奨コマンド
                new CommandNode
                {
                    Code = '\x3a',
                    Description = "GS : マクロ定義の開始・終了",
                },
                new CommandNode
                {
                    Code = '\x42',
                    Description = "GS B 白黒反転印字の指定・解除",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x43',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x30',
                            Description = "GS C 0   [非推奨コマンド] カウンターの印字モードの設定",
                            Skip = 2,
                        },
                        new CommandNode
                        {
                            Code = '\x31',
                            Description = "GS C 1   [非推奨コマンド] カウントモードの設定(A)",
                            Skip = 6,
                        },
                        new CommandNode
                        {
                            Code = '\x32',
                            Description = "GS C 2   [非推奨コマンド] カウンター値の設定",
                            Skip = 2,
                        },
                        new CommandNode
                        {
                            Code = '\x3b',
                            Description = "GS C ;   [非推奨コマンド] カウントモードの設定(B)",
                            Skip = 10,
                        },
                    },
                },
                // TODO GS D 
                new CommandNode
                {
                    Code = '\x48',
                    Description = "GS H HRI文字の印字位置の選択",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x49',
                    Description = "GS I プリンターID の送信",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x4c',
                    Description = "GS L 左マージンの設定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x50',
                    Description = "GS P 基本計算ピッチの設定",
                    Skip = 2,
                },
                // TODO GS Q 0   [非推奨コマンド]
                new CommandNode
                {
                    Code = '\x54',
                    Description = "GS T 行の先頭への印字位置の移動",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x56',
                    Description = "GS V 用紙のカット",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x57',
                    Description = "GS W 印字領域幅の設定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x5c',
                    Description = "GS \\ ページモードにおける文字縦方向相対位置の指定",
                    Skip = 2,
                },
                new CommandNode
                {
                    Code = '\x5e',
                    Description = "GS ^ マクロの実行",
                    Skip = 3,
                },
                new CommandNode {
                    Code = '\x61',
                    Description = "GS a 自動ステータス送信の設定",
                    Skip = 1,
                },
                new CommandNode {
                    Code = '\x62',
                    Description = "GS b スムージングの指定・解除",
                    Skip = 1,
                },
                new CommandNode {
                    Code = '\x63',
                    Description = "GS c   [非推奨コマンド] カウンターの印字",
                    Skip = 1,
                },
                new CommandNode {
                    Code = '\x66',
                    Description = "GS f HRI文字のフォントの選択",
                    Skip = 1,
                },
                new CommandNode {
                    Code = '\x67',
                    Nodes = new CommandNode[]
                    {
                        new CommandNode
                        {
                            Code = '\x30',
                            Description = "GS g 0 メンテナンスカウンターの初期化",
                            Skip = 3,
                        },
                        new CommandNode
                        {
                            Code = '\x32',
                            Description = "GS g 2 メンテナンスカウンターの送信",
                            Skip = 3,
                        },
                    },
                },
                new CommandNode
                {
                    Code = '\x68',
                    Description = "GS h バーコードの高さの設定",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x6a',
                    Description = "GS j インクに関する自動ステータス送信の有効・無効",
                    Skip = 1,
                },
                new CommandNode
                {
                    Code = '\x6b',
                    Description = "GS k バーコードの印字",
                    SkipUntilNull = true,
                },
                new CommandNode
                {
                    Code = '\x72',
                    Description = "GS r ステータスの送信",
                    Skip = 1,
                }
            },
        },
    },
};

var cursor = root;
var stack = "";

for (int i = 0; i < input.Length; i++)
{
    if (cursor.Nodes.Length == 0)
    {
        cursor = root;
        stack = "";
    }
    var c = input[i];

    var target = cursor.Nodes.Where(n => n.Code == c).FirstOrDefault();
    if (target != null)
    {
        cursor = target;
    }

    stack += string.Format("{0:X}", (int)c);

    if (cursor.Description.Any())
    {
        var ags = BitConverter.ToString(Encoding.UTF8.GetBytes(input.Substring(i + 1, cursor.Skip)));
        Console.WriteLine("{0}\t{1}\t({2})", stack, cursor.Description, ags);
    }

    i += cursor.Skip;
}

class CommandNode
{
    public char Code { get; set; }
    public CommandNode[] Nodes { get; set; } = Array.Empty<CommandNode>();
    public string Description { get; set; } = "";
    public int Skip = 0;
    public bool SkipUntilNull = false;
}
