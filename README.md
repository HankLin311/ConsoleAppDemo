# ConsoleAppDemo



### 為什麼要實作

- 步驟容易被寫得混淆不清
- 顯示步驟的文字寫在 console.write 或是註解中，在閱讀程式碼的時候不易發現
- 不好找出每個步驟的 input 和 output 是什麼

### 解決方法

- 使用 StepManager class 的靜態實作嚴格控制每個步驟

### 達成效果

- 將每個步驟都列舉清楚
- 執行程式顯示文字會固定在 StepManager.Step 或 StepManager.StepAsync 中，不用在特別寫上一堆 console.writeline
- 嚴格控制 input 和 output ， 開發時可以習慣性將參數包成物件 (除非參數只有1個)
- 以上三點皆包含提高可讀性

### 參考:

- Me


以上有什麼建議都可以和我討埨
