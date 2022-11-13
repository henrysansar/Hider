using Sansar.Simulation;
using System;
using Sansar.Script;
using Sansar;
using System.Collections.Generic;
public class HiderV2: SceneObjectScript {
	public String Show = "";
    public String Hide = "";
    public int Channel = 0;
    public String StartMode ="";
    public bool Debug = false;
    public float HideOffset = 0f;
    private List <RigidBodies> Rs = new List <RigidBodies> ();
    private List <MeshComponent> Ms = new List <MeshComponent> ();
    private List <float> _Intensity = new List <float> ();
    private List <Color> _Color = new List <Color> ();
    private List <LightComponent> Light = new List <LightComponent> ();
	public override void Init() {
        for(int i=0; i < 50; i++){
            try {
                RigidBodyComponent rb = null;
                MeshComponent m = null;
                LightComponent l = null;
                if (ObjectPrivate.TryGetComponent<LightComponent>((uint)i , out l)) {
                    Light.Add(l);
                    _Intensity.Add(l.GetRelativeIntensity());
                    _Color.Add(l.GetNormalizedColor());
                    if(Debug) {
                        Log.Write("Adding Light...");
                    }
                }
                if (ObjectPrivate.TryGetComponent<RigidBodyComponent>((uint)i , out rb)) {
                    RigidBodies R = new RigidBodies();
                    R.cmp = rb;
                    R.pos = rb.GetPosition();
                    Rs.Add(R);
                    if(Debug) {
                        Log.Write("Adding Rigid Body...");
                    }
                }
                if (ObjectPrivate.TryGetComponent<MeshComponent>((uint)i , out m)) {
                    if(Debug) {
                        Log.Write("Adding Mesh...");
                    }
                    Ms.Add(m);
                }
            }
            catch(Exception) { }
            if(Debug) {
                Log.Write("Total Lights:" + Light.Count.ToString());
                Log.Write("Total Rigid Bodies:" + Rs.Count.ToString());
                Log.Write("Total Meshes:" + Ms.Count.ToString());
            }
        }
        ScenePrivate.Chat.Subscribe(Channel, null, ChatMessage);
        if(StartMode == "h") {
            _Hide();
        }
        if(StartMode == "s") {
            _Show();
        }
	}
    private void ChatMessage(int Channel, string Source, SessionId SourceId, ScriptId SourceScriptId, string Message) {
        if(Message ==Hide) {
            _Hide();
        }
        if(Message ==Show) {
            _Show();
        }
    }
    private void _Hide() {
        if(Debug) {
            Log.Write("Hidding...");
        }
        for(int i=0; i < Rs.Count; i++){
            Rs[i].cmp.SetPosition(new Vector(Rs[i].pos.X,Rs[i].pos.Y, Rs[i].pos.Z + HideOffset));
        }
        for(int i=0; i < Ms.Count; i++){
            Ms[i].SetIsVisible(false);
        }
        for(int i=0; i < Light.Count; i++){
            Light[i].SetColorAndIntensity(Sansar.Color.White,0f);
        }
    }
    private void _Show() {
        if(Debug) {
            Log.Write("Showing...");
        }
        for(int i=0; i < Rs.Count; i++){
            Rs[i].cmp.SetPosition(Rs[i].pos);
        }
        for(int i=0; i < Ms.Count; i++){
            Ms[i].SetIsVisible(true);
        }
        for(int i=0; i < Light.Count; i++){
            Light[i].SetColorAndIntensity(_Color[i],_Intensity[i]);
        }
    }
}
public class RigidBodies {
	public RigidBodyComponent cmp {
		get;
		set;
	}
    public Vector pos {
        get;
		set;
    }
}