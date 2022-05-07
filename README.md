
```
$ echo "Hello" | receiptio -p escpos | hexdump -C
00000000  1b 40 1d 61 00 1b 4d 30  1c 28 41 02 00 30 00 1b  |.@.a..M0.(A..0..|
00000010  20 00 1c 53 00 00 1b 32  1b 7b 00 1c 2e 1b 2d 30  | ..S...2.{....-0|
00000020  1c 2d 30 1b 45 30 1d 42  30 1d 21 00 1d 4c 00 00  |.-0.E0.B0.!..L..|
00000030  1d 57 40 02 1b 61 00 1b  24 00 00 1b 5c 02 01 1b  |.W@..a..$...\...|
00000040  2d 30 1c 2d 30 1b 45 30  1d 42 30 1d 21 00 48 65  |-0.-0.E0.B0.!.He|
00000050  6c 6c 6f 0a 1b 2d 30 1c  2d 30 1b 45 30 1d 42 30  |llo..-0.-0.E0.B0|
00000060  1d 21 00 1d 4c 00 00 1d  57 40 02 1b 61 00 1b 24  |.!..L...W@..a..$|
00000070  00 00 1b 2d 30 1c 2d 30  1b 45 30 1d 42 30 1d 21  |...-0.-0.E0.B0.!|
00000080  00 20 0a 1d 56 42 00 1d  72 31                    |. ..VB..r1|
0000008a
```

```
$ echo "Hello" | receiptio -p escpos | ./escpos-parser
1B40    ESC @ プリンターの初期化        ()
1D61    GS a 自動ステータス送信の設定   (00)
1B4D    ESC M 文字フォントの選択        (30)
1C2841  FS ( A   <機能48> 漢字フォントの選択    (02-00-30-00)
1B20    ESC SP 文字の右スペース量の設定 (00)
1C53    FS S 漢字のスペース量の設定     (00-00)
1B32    ESC 2 初期改行量の設定  ()
1B7B    ESC { 倒立印字の指定・解除      (00)
1C2E    FS . 漢字モードの解除   ()
1B2D    ESC - アンダーラインの指定・解除        (30)
1C2D    FS - 漢字アンダーラインの指定・解除     (30)
1B45    ESC E 強調印字の指定・解除      (30)
1D42    GS B 白黒反転印字の指定・解除   (30)
1D21    GS ! 文字サイズの指定   (00)
1D4C    GS L 左マージンの設定   (00-00)
1D57    GS W 印字領域幅の設定   (40-02)
1B61    ESC a 位置揃え  (00)
1B24    ESC $ 絶対位置の指定    (00-00)
1B5C    ESC \ 相対位置の指定    (02-01)
1B2D    ESC - アンダーラインの指定・解除        (30)
1C2D    FS - 漢字アンダーラインの指定・解除     (30)
1B45    ESC E 強調印字の指定・解除      (30)
1D42    GS B 白黒反転印字の指定・解除   (30)
1D21    GS ! 文字サイズの指定   (00)
48656C6C6FA     LF 印字改行     ()                  <-------- TODO
1B2D    ESC - アンダーラインの指定・解除        (30)
1C2D    FS - 漢字アンダーラインの指定・解除     (30)
1B45    ESC E 強調印字の指定・解除      (30)
1D42    GS B 白黒反転印字の指定・解除   (30)
1D21    GS ! 文字サイズの指定   (00)
1D4C    GS L 左マージンの設定   (00-00)
1D57    GS W 印字領域幅の設定   (40-02)
1B61    ESC a 位置揃え  (00)
1B24    ESC $ 絶対位置の指定    (00-00)
1B2D    ESC - アンダーラインの指定・解除        (30)
1C2D    FS - 漢字アンダーラインの指定・解除     (30)
1B45    ESC E 強調印字の指定・解除      (30)
1D42    GS B 白黒反転印字の指定・解除   (30)
1D21    GS ! 文字サイズの指定   (00)
20A     LF 印字改行     ()
1D56    GS V 用紙のカット       (42-00)
1D72    GS r ステータスの送信   (31)
```
