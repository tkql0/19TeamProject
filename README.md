# 19TeamProject

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [주요기능](#주요기능)
4. [개발기간](#개발기간)
5. [와이어프레임](#와이어프레임)
6. [UML DIAGRAM](#uml-diagram)
7. [Trouble Shooting](#trouble-shooting)
8. [프로젝트를 마치며](#프로젝트를-마치며)
    
## 프로젝트 소개
이번 프로젝트에서는 그동안 배운 유니티의 다양한 기능과 C# 문법을 활용해 추억의 게임 벽돌 깨기를 현대적인 버전으로 해석했습니다.

## 팀소개
저희 19조는 각기 다른 개성과 재능을 지닌 다섯 명의 개인으로 이루어진 팀입니다. 협력과 공유의 경험을 통해 저희는 서로의 차이를 녹이고, 하나의 응집력 있는 팀으로 통합하는 것을 목표로 합니다. 숙련된 장인이 재료를 멋진 형태로 조형하듯, 저희는 지속해서 서로 소통하고 적응하여 발전하며, 함께 해결책을 찾고 강한 유대감을 형성하기 위해 최선을 다하고 있습니다.

## 주요기능

- 아이템
공 크기 커짐/작아짐
공 개수 두 배로 늘어남

패들 길이 증가/감소
패들 속도가 가속/급감

점수 500점 획득 아이템

- 특수 레벨
특수 레벨에서는 벽돌로 위장한 몬스터가 나타나며 몬스터의 체력은 무한대! 이 몬스터들은 맞을 때마다 특정 확률로 아이템을 뱉어냅니다. 만약 벽돌이 5번 공에 맞게 된다면 본 모습을 드러내며 그 짧은 시간 동안에는 아이템을 뱉을 수 없습니다!

- 스코어 보드
만약 플레이어가 매 스테이지마다 자신이 얼마나 높은 점수를 얻었는지 확인하고 싶다면 스코어 보드를 클릭하여 확인할 수 있습니다!

- 멀티 플레이어 모드
혼자 플레이하기에 외로우시다면 친구와 함께 플레이해 보세요! 1P: A, D로 움직이며 2P: <-, -> 고 움직입니다!

- 생생한 사운드와 화면 전환 효과
긴장감 넘치는 사운드, 벽돌이 깨질 때마다 들리는 경쾌한 소리! 저희 19조의 로고가 화면전환 시마다 보이는 것은 덤!

## 개발기간
- 2024.10.15(화) ~ 2024.10.22(화)

## 와이어프레임
<img width="556" alt="Screenshot 2024-10-20 at 07 51 32" src="https://github.com/user-attachments/assets/ff0b0b7d-c782-4fd3-b884-d25aed019ea2">
<img width="772" alt="Screenshot 2024-10-20 at 07 51 49" src="https://github.com/user-attachments/assets/ad994364-8a0d-4183-9e15-c2d15432e18a">

## UML DIAGRAM
![image](https://github.com/user-attachments/assets/5e4d47fe-2543-475e-9756-18d494966773)
발표 자료: https://www.canva.com/design/DAGT7VXHfjg/gYfX2kfhSfPO6Rd2ZKIqWA/view?utm_content=DAGT7VXHfjg&utm_campaign=designshare&utm_medium=link&utm_source=editor
## Trouble Shooting

김준식 - 공의 속도 제한 : FixedUpdate에서 현재 움직이는 방향으로 최소or최대속도를 곱하여 제어
손대오 - 아이템 레이어가 안먹히는 버그 : LayerMask 대신 Int값으로 대체
손대오 - 아이템 접촉시 속도가 변하지 않는 에러 : 프로퍼티값 정확하게 기입 + 캡슐화로 오류 방지
손대오 - 아이템 2배시 초기값이 기존 볼을 따라가지 않는 에러 : 클래스를 참조하여 이벤트 발생X --> 프로퍼티를 참조하여 이벤트 발생 O
## 프로젝트를 마치며

팀장. 김준식: 팀 프로젝트를 하며 저의 부족한 점을 많이 느꼈고 수업 이후에도 공부를 하거나 개발을 하는 팀원 분들을 보며 나도 더 노력해야겠다고 생각했습니다. 팀원분들 모두 프로젝트동안 감사했습니다.

팀원. 박은설: 이번 팀 프로젝트를 마치고, 성취감과 함께 보람찬 기분이 듭니다. 함께해 준 팀원분들께 정말 감사드리며, 저희가 이번 7일 동안 이룬 모든 것이 정말 뿌듯합니다. 저희가 언제 다시 볼 수 있을지 모르겠지만 여러분의 앞날이 항상 밝고 좋은 일로 가득하기를 바랍니다!

팀원. 서영석: 좋은 팀원분들과 함께 재밌게 프로젝트를 만들고, 열심히 코드를 작성할 수 있어서 정말 뜻깊은 시간이었습니다. 특히 팀원분들끼리 서로 알고 있는 유니티 지식을 공유하며 함께 성장할 수 있어 너무 감사했습니다.

팀원. 손대오: 과제를 진행하면서 강의 내용을 최대한 많이 반영하도록 해봤습니다. 단일책임원칙과 코드를 추가하냐 안하냐에 따라 기능이 추가되고 안되도록 했고, 유지보수에 최대한 신경을 많이 썼습니다. 실제로 강의 내용을 적용하면서 이전보다 코드가 좀 더 발전하게 되었습니다. 아직 코딩속도가 느려 다양한 기능에 도전하지 못한 점이 아쉬웠지만, 팀과제를 하면서 코드와 유니티에 대한 여러 지식을 나누면서 학습하여 좀 더 빠르게 성장할 수 있어서 좋았습니다.

팀원. 이재민: 이론으로만 배우다가 실제로 협업하면서 유니티로 개발해보니 생각했던 것과 다른점이 많았고 또한 많은걸 배운것 같습니다. 같이 열심히 작업한 팀원분들 모두 수고하셨습니다.
