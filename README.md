# Portfolio

渡邊 恭伸のポートフォリオ

## プロジェクト概要

### AudioDeviceSettingWPF
Windowsの音声デバイス設定を簡単に切り替えるためのWPFアプリケーションです。
- モダンなUIデザイン
- 直感的な操作性
- システムトレイでの常駐機能

### WindowsSettings
Windowsの音声デバイス設定を切り替えるためのWindowsFormsアプリケーションです。
- AudioDeviceSettingWPFの前身となるプロジェクト
- 基本的な機能を実装

## 開発環境

- Visual Studio 2022
- Windows 10/11

## デバッグ方法

1. Visual Studioでソリューションファイル（.sln）を開きます
2. F5キーを押すか、デバッグメニューから「デバッグの開始」を選択します

## プロジェクト構成

### AudioDeviceSettingWPF
- AudioDeviceSettingWPF.csproj - WPFアプリケーションのメインプロジェクト
- モダンなUIと機能を実装

### WindowsSettings
- AudioDeviceSetting.csproj - コアライブラリ
- AudioDeviceForm.csproj - WindowsFormsアプリケーション
