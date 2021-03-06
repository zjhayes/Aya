// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""22e7f7b4-6304-41ca-9510-dc5de3559358"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dee9e687-319a-4742-acf4-aed7ec224c07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""55eccc37-2744-4fee-97f5-ddde7d66fac8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""a509668c-3d26-4897-a753-5f66777aeb62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""f8e00508-4232-47cf-98e1-bb1c60ddf102"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4fd12360-d23d-4c32-b14b-031486b4e09b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d620405-9c24-45c4-ab3a-be3dc774de25"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""a13602ad-0783-41d7-b20b-82e868d9b38b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""27b89b0c-644a-45f2-bd47-7a9739ee86cd"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""662cf012-ed7d-43dd-a455-cc9e7672097c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ce4fd050-e572-4368-9873-40f57880aefd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8d300aa4-f41a-4ec5-aeee-5eaf2381a4a4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""797e8748-d3d6-4be3-8aba-8c39a7a81598"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a4961db-a39c-4431-95f2-42ce76fe5e6b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""89c06990-6f64-44af-95cd-f4fc72029bac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""771730e0-9404-4735-9b81-13bce2828376"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1d4673c3-a9fa-4f7e-bcea-c212a2e28098"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftThumb"",
                    ""id"": ""54727e55-1ca4-4ee9-8c87-ab183cacbfb0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3bd04f0e-7d40-4db8-a702-77a423a45c25"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cabd475a-360e-439b-94bd-a3857081fda9"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44ba691f-9fec-4f79-8de8-ed07ef35f496"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""658ab01a-13fd-4449-9c2d-0c759354a7e2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b4141c5-2f7e-41c6-b13d-f2740d85120e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0295ab99-2d7a-41cf-a413-98e5a51d78c0"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5256ce47-ac9d-4300-a399-7a2b93d4d9f9"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc7b3abb-15d6-4c02-b87b-b684f578fe53"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interact"",
            ""id"": ""df226fa4-1e64-4b8d-bfaf-1ceedfb22d1c"",
            ""actions"": [
                {
                    ""name"": ""Attune"",
                    ""type"": ""Button"",
                    ""id"": ""a10c1d00-0df3-4b1c-8dd6-7db61359c876"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UnequiptAll"",
                    ""type"": ""Button"",
                    ""id"": ""34dd4276-b051-4ef7-b1e2-f8190dbdb4ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""ed8912b8-fd6c-49b0-846f-d6792257ac2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""5736f65b-60e4-4187-b7e1-d9a107876d45"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""061565d8-7820-4a20-99d6-bac40fb80f17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d1f5e907-740d-43ff-beb9-dd7da8fc6e7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfe10ff4-4fff-4988-9ee2-680f21bbc9ff"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Attune"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2940febe-8d53-49ac-9d83-3fa445792110"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attune"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2974146-15e1-4538-8ce9-c6e17b4a18b6"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""UnequiptAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d86856cd-6eee-43a9-89df-e7fb1d823e80"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""754d846f-6946-460c-86f8-faa84f1bb36d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c41ed7c3-1aef-4bf2-b240-4d2b437445b9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3efed338-2d79-42d8-afa4-810e5d5be85c"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e77b69c6-b54b-4dba-95e8-5d07b26a44de"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HUD"",
            ""id"": ""71116ab0-6957-4ce4-8871-a994ed61860e"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""ad8b3065-4b1f-41c8-8189-0c43d4694627"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16c736fd-4b3a-493c-98fa-30d2b44d6b66"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""59da4746-07dd-4086-b8da-aba4ca65bf69"",
            ""actions"": [
                {
                    ""name"": ""Look456"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ece492a6-a90a-4db9-affb-3bbf8cf73734"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""Value"",
                    ""id"": ""23e93aff-0d77-4fd9-9b17-0a165923b2cf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pitch"",
                    ""type"": ""Value"",
                    ""id"": ""bb5513c0-06a8-480b-aa2f-de8c9f928fc8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeView"",
                    ""type"": ""Button"",
                    ""id"": ""d8f10700-1d8e-44bc-847e-a302f6c26dcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""4cb00e35-fcb8-4614-aca1-12d053bedad9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2ad03aba-4244-4903-90e7-4b75825394d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look456"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a55f4ce6-403c-433a-8424-d53d5b3bfaeb"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look456"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1825f6d3-931e-4e18-aa3a-f431b0d7ab6c"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look456"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b254fdaf-1f50-4fde-a31b-e4cf17b8adc7"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look456"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e9228ed5-2595-44a8-8d2a-fe98a0011aa2"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look456"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0e098e60-67c2-4a27-920e-8800e9f9cec8"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""640c7a93-717d-4de7-9cd4-35ab13717ad4"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6739d2c-2886-4810-8b2c-ccfee85643fc"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dce470f-9827-4342-8de6-c1f19023cdaf"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca866210-0adf-446f-a26b-310919f14d76"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ChangeView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bd6e894-96ed-4d4b-964e-dda2a98907d2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03bcee60-c11f-4e48-a21b-8b25ea70b2bf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df3c4833-ba79-4943-ae1e-c505a7966f27"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Run = m_Movement.FindAction("Run", throwIfNotFound: true);
        m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
        // Interact
        m_Interact = asset.FindActionMap("Interact", throwIfNotFound: true);
        m_Interact_Attune = m_Interact.FindAction("Attune", throwIfNotFound: true);
        m_Interact_UnequiptAll = m_Interact.FindAction("UnequiptAll", throwIfNotFound: true);
        m_Interact_LeftClick = m_Interact.FindAction("LeftClick", throwIfNotFound: true);
        m_Interact_MousePosition = m_Interact.FindAction("MousePosition", throwIfNotFound: true);
        m_Interact_RightClick = m_Interact.FindAction("RightClick", throwIfNotFound: true);
        m_Interact_Shoot = m_Interact.FindAction("Shoot", throwIfNotFound: true);
        // HUD
        m_HUD = asset.FindActionMap("HUD", throwIfNotFound: true);
        m_HUD_Inventory = m_HUD.FindAction("Inventory", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Look456 = m_Camera.FindAction("Look456", throwIfNotFound: true);
        m_Camera_Yaw = m_Camera.FindAction("Yaw", throwIfNotFound: true);
        m_Camera_Pitch = m_Camera.FindAction("Pitch", throwIfNotFound: true);
        m_Camera_ChangeView = m_Camera.FindAction("ChangeView", throwIfNotFound: true);
        m_Camera_Aim = m_Camera.FindAction("Aim", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Run;
    private readonly InputAction m_Movement_Crouch;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Run => m_Wrapper.m_Movement_Run;
        public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Interact
    private readonly InputActionMap m_Interact;
    private IInteractActions m_InteractActionsCallbackInterface;
    private readonly InputAction m_Interact_Attune;
    private readonly InputAction m_Interact_UnequiptAll;
    private readonly InputAction m_Interact_LeftClick;
    private readonly InputAction m_Interact_MousePosition;
    private readonly InputAction m_Interact_RightClick;
    private readonly InputAction m_Interact_Shoot;
    public struct InteractActions
    {
        private @PlayerInput m_Wrapper;
        public InteractActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attune => m_Wrapper.m_Interact_Attune;
        public InputAction @UnequiptAll => m_Wrapper.m_Interact_UnequiptAll;
        public InputAction @LeftClick => m_Wrapper.m_Interact_LeftClick;
        public InputAction @MousePosition => m_Wrapper.m_Interact_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_Interact_RightClick;
        public InputAction @Shoot => m_Wrapper.m_Interact_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Interact; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractActions set) { return set.Get(); }
        public void SetCallbacks(IInteractActions instance)
        {
            if (m_Wrapper.m_InteractActionsCallbackInterface != null)
            {
                @Attune.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnAttune;
                @Attune.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnAttune;
                @Attune.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnAttune;
                @UnequiptAll.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnUnequiptAll;
                @UnequiptAll.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnUnequiptAll;
                @UnequiptAll.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnUnequiptAll;
                @LeftClick.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnLeftClick;
                @MousePosition.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnMousePosition;
                @RightClick.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnRightClick;
                @Shoot.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_InteractActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attune.started += instance.OnAttune;
                @Attune.performed += instance.OnAttune;
                @Attune.canceled += instance.OnAttune;
                @UnequiptAll.started += instance.OnUnequiptAll;
                @UnequiptAll.performed += instance.OnUnequiptAll;
                @UnequiptAll.canceled += instance.OnUnequiptAll;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public InteractActions @Interact => new InteractActions(this);

    // HUD
    private readonly InputActionMap m_HUD;
    private IHUDActions m_HUDActionsCallbackInterface;
    private readonly InputAction m_HUD_Inventory;
    public struct HUDActions
    {
        private @PlayerInput m_Wrapper;
        public HUDActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_HUD_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_HUD; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HUDActions set) { return set.Get(); }
        public void SetCallbacks(IHUDActions instance)
        {
            if (m_Wrapper.m_HUDActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_HUDActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_HUDActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_HUDActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_HUDActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public HUDActions @HUD => new HUDActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Look456;
    private readonly InputAction m_Camera_Yaw;
    private readonly InputAction m_Camera_Pitch;
    private readonly InputAction m_Camera_ChangeView;
    private readonly InputAction m_Camera_Aim;
    public struct CameraActions
    {
        private @PlayerInput m_Wrapper;
        public CameraActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look456 => m_Wrapper.m_Camera_Look456;
        public InputAction @Yaw => m_Wrapper.m_Camera_Yaw;
        public InputAction @Pitch => m_Wrapper.m_Camera_Pitch;
        public InputAction @ChangeView => m_Wrapper.m_Camera_ChangeView;
        public InputAction @Aim => m_Wrapper.m_Camera_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Look456.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook456;
                @Look456.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook456;
                @Look456.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLook456;
                @Yaw.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnYaw;
                @Pitch.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPitch;
                @ChangeView.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeView;
                @ChangeView.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeView;
                @ChangeView.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeView;
                @Aim.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look456.started += instance.OnLook456;
                @Look456.performed += instance.OnLook456;
                @Look456.canceled += instance.OnLook456;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @ChangeView.started += instance.OnChangeView;
                @ChangeView.performed += instance.OnChangeView;
                @ChangeView.canceled += instance.OnChangeView;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IInteractActions
    {
        void OnAttune(InputAction.CallbackContext context);
        void OnUnequiptAll(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IHUDActions
    {
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnLook456(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
        void OnPitch(InputAction.CallbackContext context);
        void OnChangeView(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
