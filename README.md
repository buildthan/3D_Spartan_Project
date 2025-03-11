# 3D_Spartan_Project

내일배움캠프 과제 제출용 GitHub입니다.
해당 과제에서는 제시된 조건들 중 다음과 같은 기능이 구현되어 있습니다.

---

1. 기본 이동 및 점프

프로젝트 실행 후 wasd로 이동, space로 점프가 가능합니다.

---

2. 체력바 UI

![image](https://github.com/user-attachments/assets/139cfad7-a07f-429b-adde-e7bd2618027e)


프로젝트 실행 시 캐릭터의 hp가 50이 되며, 이후 매초 1씩 자동으로 회복합니다.
해당 정보는 오른쪽 하단에서 확인 가능합니다.

---

3. 동적 환경 조사

![image](https://github.com/user-attachments/assets/e22b300b-c61a-47f3-9bfb-3375082fb2ae)

아이템을 쳐다보면 해당 아이템에 관한 정보를 얻을 수 있습니다.

---

4. 점프대

![image](https://github.com/user-attachments/assets/75bc927b-2a44-4445-a733-14904d7c13d9)

밟을 시 정해진 Force만큼 위로 솟구쳐 오릅니다.

---

5. 아이템 데이터

Speed Up 아이템을 만들기 위해 ScriptableObject를 정의해 주었습니다.

---

6. 아이템 사용

Speed Up 아이템과 접촉 시, 자동으로 일정 시간동안 플레이어의 속도가 증가하며, 게임 오브젝트는 파괴됩니다.

---

7. 3인칭 카메라

카메라가 Player의 뒷모습을 비추도록 위치를 조정했습니다.

---

8. 다양한 아이템 구현

Speed Up 아이템 뿐만 아니라, Jump Up 아이템도 추가해주었습니다.
